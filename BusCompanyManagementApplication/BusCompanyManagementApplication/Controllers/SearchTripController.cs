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
{   //[Authorize]
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
        //[Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult UpdateTrip()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BookSeat(Guid id)
        {            
            var buyVm = new BuyTicketViewModel()
            {
                TripId = id, SeatNumber = -1
            };

            return View(buyVm);
        } 

        [HttpPost]
        public IActionResult BookSeat([FromForm] BuyTicketViewModel Vm) 
        {
            var userId = userManager.GetUserId(User);
            var personalTrip = historyTripsService.GetPersonalTripByUserId(userId);
            historyTripsService.AddTripInHistory(Vm.TripId.ToString(), personalTrip.PersonalTripId.ToString(), "", 122, Vm.SeatNumber, 0);
            return RedirectToAction("Index", "HistoryTrip");
        }
        
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

        [HttpPost]
        public IActionResult DeleteTrip(Guid id)
        {
            tripsService.DeleteTrip(id);
            return Redirect(Url.Action("Index", "SearchTrip"));
        }

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