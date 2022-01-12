using AutoRaceCalendarApp.UI.Models.Team;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutoRaceCalendarApp.UI.Controllers
{
    public class TeamController : Controller
    {
        private WebClient _client;
        private int _amount = 50;

        public TeamController()
        {
            GetClient();
        }

        public ActionResult Index(int pageNr, string searchString, int? amount)
        {

            if (pageNr == 0)
            {
                pageNr = 1;
            }
            if (TempData["amount"] is not null)
            {
                _amount = (int)TempData["amount"];
            }

            if(amount is not null)
            {
                _amount = (int)amount;
            }

            ICollection<TeamViewModel> teams = GetAllTeamsAsync(pageNr, _amount, searchString);
            if (teams.Count > 0)
            {
                TempData["amount"] = _amount;
                TempData["searchString"] = searchString;
                TempData["pageNr"] = pageNr;
                return View("Index", teams);

            }
            else
            {
                TempData["amount"] = _amount;
                TempData["pageNr"] = pageNr;
                TempData["searchString"] = searchString;
                TempData["Error"] = "No records Found";
                return View("Index", teams);

            }
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View(new TeamViewModel());
        }


        [ValidateAntiForgeryToken]
        public ActionResult CreateTeam(TeamViewModel team)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var json = JsonConvert.SerializeObject(team);
                    var res = _client.UploadString("Team/addTeam", json);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    TempData["Error"] = "Team with this name already exist.";
                    return View("Create", team);
                }


            }
            return View("Create", team);
        }

        public ActionResult Edit(int id)
        {
            return View();
        }


        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }


        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ICollection<TeamViewModel> GetAllTeamsAsync(int pageNr, int amount, string searchString)
        {
            var json = _client.DownloadString($"Team/getByPage/{pageNr}/{amount}/{searchString}");

            if (json is not null)
            {
                var result = (new JavaScriptSerializer()).Deserialize<ICollection<TeamViewModel>>(json);
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
        public ActionResult SetAmount(string amount, string searchString)
        {
            TempData["amount"] = int.Parse(amount);
            return RedirectToAction("Index", new { searchString });

        }
    }
}