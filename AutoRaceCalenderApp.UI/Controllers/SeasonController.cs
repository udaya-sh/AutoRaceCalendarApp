using AutoRaceCalendarApp.UI.Models;
using AutoRaceCalenderApp.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace AutoRaceCalendarApp.UI.Controllers
{
    public class SeasonController : Controller
    {
        private WebClient _client;
        private int _amount = 50;


        public SeasonController()
        {
            GetClient();
        }

        public ActionResult Index(int pageNr, int sortingChoice)
        {
            if (pageNr == 0)
            {
                pageNr = 1;
            }
            if (HttpContext.Session.GetInt32("_Amount") is not null)
            {
                _amount = (int)HttpContext.Session.GetInt32("_Amount");
            }
            ICollection<SeasonViewModel> seasons = GetAllSeasonsAsync(pageNr, _amount);
            if (seasons.Count > 0)
            {
                TempData["pageNr"] = pageNr;
                var seasonsView = GetAllSeasonsSorted(seasons, sortingChoice);
                return View("Index", seasonsView);

            }
            else
            {
                TempData["pageNr"] = pageNr;
                TempData["Error"] = "No records Found";
                return View("Index", seasons);

            }
        }

        public ActionResult Details(int id)
        {
            try
            {
                var seasonJson = _client.DownloadString($"Season/{id}");
                var racesJson = _client.DownloadString($"Race/getBySeasonId/{id}");

                var season = (new JavaScriptSerializer()).Deserialize<SeasonViewModel>(seasonJson);
                var races = (new JavaScriptSerializer()).Deserialize<IEnumerable<RaceViewModel>>(racesJson);
                SeasonRaceViewModel seasonRace = new(season, races);
                return View(seasonRace);

            }
            catch
            {
                return View("Error", new ErrorViewModel());

            }
        }

        public ActionResult Create(int serieId)
        {
            SeasonViewModel season = new()
            {
                SerieId = serieId
            };
            return View(season);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSeason(SeasonViewModel season)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    var json = JsonConvert.SerializeObject(season);
                    var res = _client.UploadString("Season/addSeason", json);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    TempData["Error"] = "Season with this name already exist or Serie Id does not exist";
                    return View("Create", season);
                 }
            }
            return View("Create", season);
        }

        public ActionResult Edit(int id)
        {
            try
            {
                string json = _client.DownloadString("Season/" + id);
                var result = (new JavaScriptSerializer()).Deserialize<SeasonViewModel>(json);

                return View("Edit", result);
            }
            catch
            {
                return View("Error", new ErrorViewModel());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSeason( SeasonViewModel season)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string data = JsonConvert.SerializeObject(season);
                    _client.UploadString("Season/updateSeason/", data);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    TempData["Error"] = "Season with this name already exist.";
                    return View("Create", season);
                }
            }
            return View("Edit", season);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                string json = _client.DownloadString("Season/" + id);
                var result = (new JavaScriptSerializer()).Deserialize<SeasonViewModel>(json);

                return View("Delete", result);
            }
            catch
            {
                return View("Error", new ErrorViewModel());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSeason(int seasonId)
        {
            try
            {
                string apiUri = "Season/deleteSeason/" + seasonId;
                _client.UploadString(apiUri, "POST", "");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error", new ErrorViewModel());
            }
        }

        public ICollection<SeasonViewModel> GetAllSeasonsAsync(int pageNr, int amount)
        {
            var json = _client.DownloadString($"Season/getByPage/{pageNr}/{amount}");

            if (json is not null)
            {
                var result = (new JavaScriptSerializer()).Deserialize<ICollection<SeasonViewModel>>(json);
                return result;
            }
            return null;
        }


        public ICollection<SeasonViewModel> GetAllSeasonsSorted(ICollection<SeasonViewModel> seasons, int sortingChoice)
        {

            List<SeasonViewModel> sortedList = (List<SeasonViewModel>)seasons;

            switch (sortingChoice)
            {
                case 0:
                    sortedList = sortedList.OrderBy(s => s.Serie.Name).ToList();
                    break;
                case 1: sortedList.OrderBy(s => s.Name);
                    break;
                case 2:
                    sortedList = sortedList.OrderByDescending(s => s.StartDate).ToList();
                    break;
                case 3:
                    sortedList = sortedList.OrderBy(s => s.EndDate).ToList();
                    break;
                case 4:
                    sortedList = sortedList.OrderByDescending(s => s.Active).ToList();
                    break;
            }
            return sortedList;
        }

        public void GetClient()
        {
            _client = new();
            _client.Headers["Content-type"] = "application/json";
            _client.Encoding = Encoding.UTF8;
            _client.BaseAddress = "https://localhost:44391/api/";

        }

        public ActionResult SetAmount(string amount)
        {
            var isNumeric = int.TryParse(amount, out _ );
            if (isNumeric)
            {
                HttpContext.Session.SetInt32("_Amount", int.Parse(amount));
            }
            return RedirectToAction(nameof(Index));

        }
    }
}
