using AutoRaceCalendarApp.UI.Models;
using AutoRaceCalenderApp.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AutoRaceCalenderApp.UI.Controllers
{
    public class CircuitController : Controller
    {

        private HttpClient _client;

        public CircuitController()
        {
            GetClient();
        }

        public ActionResult Index()
        {
            var Circuits = GetAllCircuitsAsync();
            if (Circuits is not null)
            {
                return View(Circuits);

            }
            return View("Error", new ErrorViewModel());

        }

        public ActionResult Details(int id)
        {
            try
            {
                var racesJson = _client.GetStringAsync($"Race/getByCircuitId/{id}").Result;
                var CircuitJson = _client.GetStringAsync($"Circuit/{id}").Result;

                var Circuit = (new JavaScriptSerializer()).Deserialize<CircuitViewModel>(CircuitJson);
                var races = (new JavaScriptSerializer()).Deserialize<IEnumerable<RaceViewModel>>(racesJson);
                CircuitRaceViewModel CircuitSeason = new(Circuit, races);
                return View(CircuitSeason);

            }
            catch
            {
                return View("Error", new ErrorViewModel());

            }
        }

        public ActionResult Create()
        {
            return View(new CircuitViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CircuitViewModel Circuit)
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

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
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

        [HttpPost]
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

        public IEnumerable GetAllCircuitsAsync()
        {
            var json = _client.GetStringAsync(_client.BaseAddress + "Circuit").Result;

            if (json is not null)
            {
                var result = (new JavaScriptSerializer()).Deserialize<IEnumerable<CircuitViewModel>>(json);
                return result;
            }
            return null;
        }

        public void GetClient()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.BaseAddress = new Uri("https://localhost:44391/api/");
            //_client.DefaultRequestHeaders.Add("Authorization", "Basic " + authstring);

        }
    }
}
