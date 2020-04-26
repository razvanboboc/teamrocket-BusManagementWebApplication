using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusCompanyManagement.ApplicationLogic.DataModel;
using BusCompanyManagement.ApplicationLogic.Services;
using BusCompanyManagementApplication.Models.TripModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusCompanyManagementApplication.Controllers
{
    public class SearchTripController : Controller
    {
        private readonly TripsService tripsService;

        public SearchTripController(TripsService tripsService)
        {

            this.tripsService = tripsService;
        }

        // GET: Bus
        public ActionResult Index()
        {
            try
            {
                var trips = tripsService.GetTrips();

                return View(new TripViewModel { Trips = trips });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received");
            }
        }

        [HttpGet]
        public IActionResult AddTrip()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DeleteTrip()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpdateTrip()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTrip([FromForm]AddTripViewModel model)
        {   //program crashes for this. 
            //if (!ModelState.IsValid) 
            //{

            //    return BadRequest();
            //}

            tripsService.AddTrip(model.Destination, model.Arrival, model.ArrivalTime, model.DestinationTime);

            return Redirect(Url.Action("Index", "SearchTrip"));

        }

        [HttpPost]
        public IActionResult DeleteTrip(Guid id)
        {
            tripsService.DeleteTrip(id);
            return Redirect(Url.Action("Index", "SearchTrip"));
        }

        [HttpPost]
        public IActionResult UpdateTrip([FromForm]UpdateTripViewModel model, String id)
        {
            tripsService.UpdateTrip(id, model.Destination, model.Arrival,  model.ArrivalTime, model.DestinationTime);
            return Redirect(Url.Action("Index", "SearchTrip"));
        }


    }
}