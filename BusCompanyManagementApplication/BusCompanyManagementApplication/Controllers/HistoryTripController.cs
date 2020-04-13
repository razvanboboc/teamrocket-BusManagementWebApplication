using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusCompanyManagement.ApplicationLogic.DataModel;
using BusCompanyManagement.ApplicationLogic.Services;
using BusCompanyManagementApplication.Models.HistoryTrip;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BusCompanyManagementApplication.Controllers
{
    [Authorize]
    public class HistoryTripController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly HistoryTripsService historyTripsService;        

        public HistoryTripController(UserManager<IdentityUser> userManager, HistoryTripsService historyTripsService)
        {
            this.userManager = userManager;
            this.historyTripsService = historyTripsService;
        }
       //problem
        public ActionResult Index()
        {
            try
            {
                var userId = userManager.GetUserId(User);
                //var personalTripId = historyTripsService.GetPersonalTripByUserId(userId);//            
                var historyTrip = historyTripsService.GetTripHistoryByUserId(userId);
                //var trip = historyTripsService.GetTripByPersonalTripId(personalTripId.ToString());//
                
                return View(new HistoryTripsViewModel { historyTrip = historyTrip});
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received");
            }
        }
       
        [HttpGet]
        public IActionResult AddTripInHistory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTripinHistory([FromForm]AddTripInHistoryViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }
            // ???
            var userId = userManager.GetUserId(User);
            var personalTrips = historyTripsService.GetTripHistoryByUserId(userId);
            var personalTrip = personalTrips.FirstOrDefault();

            var trip = historyTripsService.GetTripByPersonalTripId(personalTrip.PersonalTripId.ToString());

            historyTripsService.AddTripInHistory(trip.TripId.ToString(), personalTrip.PersonalTripId.ToString(), model.Status, model.TicketPrice, model.SeatNumber, model.Rating);
            return Redirect(Url.Action("AddTripInHistory", "HistoryTrip"));
            
        }

    }
}