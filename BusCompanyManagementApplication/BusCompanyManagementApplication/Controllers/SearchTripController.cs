using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusCompanyManagement.ApplicationLogic.DataModel;
using BusCompanyManagement.ApplicationLogic.Services;
using BusCompanyManagementApplication.Models.TripModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BusCompanyManagementApplication.Controllers
{   
    public class SearchTripController : Controller
    {
        private readonly TripsService tripsService;
        private readonly BusesService busesService;
        private readonly HistoryTripsService historyTripsService;
        private readonly UserManager<IdentityUser> userManager;

        public SearchTripController(TripsService tripsService, BusesService busesService, HistoryTripsService historyTripsService, UserManager<IdentityUser> userManager)
        {

            this.tripsService = tripsService;
            this.busesService = busesService;
            this.userManager = userManager;
            this.historyTripsService = historyTripsService;
        }

        // GET: Bus
        public ActionResult Index(string arrival, string destination, DateTime arrivalTime)
        {      
            if(arrival == null || destination == null || arrivalTime == null)
            {
                var trips = tripsService.GetTrips();               
                return View(new TripViewModel { Trips = trips });
            }
            try
            {
                var trips = tripsService.GetTripsAccordingToFilters(arrival, destination, arrivalTime);

                return View(new TripViewModel { Trips = trips });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received");
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult AddTrip()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult DeleteTrip()
        {
            return View();
        }
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult UpdateTrip()
        {
            return View();
        }

        [Authorize(Roles ="User, Administrator")]
        [HttpGet]
        public IActionResult BookSeat(Guid id)
        {            
            var buyVm = new BuyTicketViewModel()
            {
                TripId = id, SeatNumber = -1
            };

            return View(buyVm);
        } 

        [Authorize(Roles ="User")]
        [HttpPost]
        public IActionResult BookSeat([FromForm] BuyTicketViewModel Vm) 
        {
            var userId = userManager.GetUserId(User);
            var personalTrip = historyTripsService.GetPersonalTripByUserId(userId);
            if(Vm.SeatNumber != -1)
            {
                historyTripsService.AddTripInHistory(Vm.TripId.ToString(), personalTrip.PersonalTripId.ToString(), "", 122, Vm.SeatNumber, 0);
                return RedirectToAction("Index", "HistoryTrip");
            }           
            return RedirectToAction("BookSeat", "SearchTrip");
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult AddTrip([FromForm]AddTripViewModel model)
        {   
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }

            tripsService.AddTrip(model.Destination, model.Arrival, model.ArrivalTime, model.DestinationTime);

            return Redirect(Url.Action("Index", "SearchTrip"));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult DeleteTrip(Guid id)
        {
            tripsService.DeleteTrip(id);
            return Redirect(Url.Action("Index", "SearchTrip"));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult UpdateTrip([FromForm]UpdateTripViewModel model, Guid id)
        {
            model.TripId = id;
           
            //if (!ModelState.IsValid)
            //{

            //    return BadRequest();
            //}

            tripsService.UpdateTrip(model.TripId, model.Destination, model.Arrival,  model.ArrivalTime, model.DestinationTime);
            return Redirect(Url.Action("Index", "SearchTrip"));
        }


    }
}