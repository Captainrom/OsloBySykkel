using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OsloBysykkelAPIConsumption.Models;
using OsloBysykkelAPIConsumption.Consumer;

namespace OsloBysykkelAPIConsumption.Controllers
{
    public class HomeController : Controller
    {
        ApiOsloBySykkel _apiOsloBySykkel;

        public HomeController()
        {
            _apiOsloBySykkel = new ApiOsloBySykkel();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("stations")]
        public async Task<IActionResult> GetStations()
        {
            var stationsWithInformation = await _apiOsloBySykkel.GetStationInformation();
            var stationsWithStatus = await _apiOsloBySykkel.GetStationStatus();

            foreach (var stationInformation in stationsWithInformation.data.stations)
            {
                foreach (var stationStatus in stationsWithStatus.data.stations)
                {
                    if (stationInformation.station_id == stationStatus.station_id)
                    {
                        stationInformation.is_installed = stationStatus.is_installed;
                        stationInformation.is_renting = stationStatus.is_renting;
                        stationInformation.num_bikes_available = stationStatus.num_bikes_available;
                        stationInformation.num_docks_available = stationStatus.num_docks_available;
                        stationInformation.last_reported = stationStatus.last_reported;
                        stationInformation.is_returning = stationStatus.is_returning;
                    }
                }
            }
            return Json(stationsWithInformation);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
