using System;
using BusCompanyManagement.ApplicationLogic.Services;
using BusCompanyManagementApplication.Models.Buses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusCompanyManagementApplication.Controllers
{
   
    public class BusController : Controller
    {
        private readonly BusesService busesService;

        public BusController(BusesService busesService)
        {
     
            this.busesService = busesService;
        }

        // GET: Bus
        public ActionResult Index(string id)
        {            
            try
            {                
                var bus = busesService.GetBusByTripId(id);

                return View(new BusViewModel { Bus = bus });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received");
            }                
        }



        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult AddBus()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult DeleteBus()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult UpdateBus()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult AddBus([FromForm]AddBusViewModel model, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            busesService.AddBus(id.ToString(), 
                            model.BusBrand, 
                            model.TotalSeats);
            return Redirect(Url.Action("Index", "Bus"));

        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult DeleteBus(Guid id)
        {
            busesService.DeleteBus(id);
            return Redirect(Url.Action("Index", "Bus"));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult UpdateBus([FromForm]UpdateBusViewModel model, Guid id)
        {
            busesService.UpdateBus(id, model.BusBrand, model.TotalSeats);
            return Redirect(Url.Action("Index", "Bus"));
        }

    }
}