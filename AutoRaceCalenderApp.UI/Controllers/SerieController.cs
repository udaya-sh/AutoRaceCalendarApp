using AutoRaceCalendarApp.UI.Models;
using AutoRaceCalenderApp.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Text;
namespace AutoRaceCalendarApp.UI.Controllers
{
    public class SerieController : Controller
    {
        private WebClient _client;
        private int _amount = 50;
        public SerieController()
        {
            GetClient();
        }

        public ActionResult Index(int pageNr, int? amount)
        {
            
            if(pageNr==0)
            {
                pageNr = 1;
            }
            if(TempData["amount"] is not null)
            {
                _amount = (int)TempData["amount"];
            }
            if (amount is not null)
            {
                _amount = (int)amount;
            }

            ICollection<SerieViewModel> series = GetAllSeriesAsync(pageNr, _amount);
            if (series.Count > 0)
            {
                TempData["amount"] = _amount;

                TempData["pageNr"] = pageNr;
                return View("Index",series);

            }
            else
            {
                TempData["amount"] = _amount;
                TempData["pageNr"] = pageNr;
                TempData["Error"] = "No records Found";
                return View("Index", series);

            }
        }

        public ActionResult Details(int id)
        {
            try
            {
                var seasonsJson = _client.DownloadString($"Season/getBySerieId/{id}");
                var serieJson = _client.DownloadString($"Serie/{id}");
            
                var serie = (new JavaScriptSerializer()).Deserialize<SerieViewModel>(serieJson);
                var seasons = (new JavaScriptSerializer()).Deserialize<ICollection<SeasonViewModel>>(seasonsJson);
                SerieSeasonViewModel serieSeason = new(serie, seasons);
                return View(serieSeason);
                
            }
            catch
            {
                return View("Error", new ErrorViewModel());

            }
        }

        public ActionResult Create()
        {
            return View(new SerieViewModel());
        }

        [ValidateAntiForgeryToken]
        public ActionResult CreateSerie(SerieViewModel serie)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var json = JsonConvert.SerializeObject(serie);
                    var res = _client.UploadString("Serie/addSerie", json);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    TempData["Error"] = "Serie with this name already exist.";
                    return View("Create", serie);
                }

            
            }
            return View("Create",serie);
        }

        public ActionResult Edit(int id)
        {
            try
            {
                string json = _client.DownloadString("Serie/" + id);
                var result = (new JavaScriptSerializer()).Deserialize<SerieViewModel>(json);

                return View("Edit", result);
            }
            catch
            {
                return View("Error", new ErrorViewModel());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSerie(int id, SerieViewModel serie)
        {
            if (ModelState.IsValid)
            {
                    try
                    {
                        string data = JsonConvert.SerializeObject(serie);
                        _client.UploadString("Serie/updateSerie/", data);
                        return RedirectToAction(nameof(Index));
                    }
                    catch
                    {
                    TempData["Error"] = "Serie with this name already exist.";
                    return View("Create", serie);
                }
            }
            return View("Edit", serie);

        }

        public ActionResult Delete(int id)
        {
            try
            {
                string json = _client.DownloadString("Serie/" + id);
                var result = (new JavaScriptSerializer()).Deserialize<SerieViewModel>(json);

                return View("Delete", result);
            }
            catch
            {
                return View("Error", new ErrorViewModel());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSerie(int serieId)
        {
            try
            {
                string apiUri = "Serie/deleteSerie/" + serieId;
                _client.UploadString(apiUri, "POST", "");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error", new ErrorViewModel());
            }
        }


        public ICollection<SerieViewModel> GetAllSeriesAsync(int pageNr, int amount)
        {
            var json = _client.DownloadString($"Serie/getByPage/{pageNr}/{amount}");

            if (json is not null)
            {
                var result = (new JavaScriptSerializer()).Deserialize<ICollection<SerieViewModel>>(json);
                return result;
            }
            return null;
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
            TempData["amount"] = int.Parse(amount);
            return RedirectToAction(nameof(Index));

        }
    }
}
