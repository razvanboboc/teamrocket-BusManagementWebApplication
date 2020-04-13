using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

    }
}