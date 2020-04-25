using System;
using BusCompanyManagement.ApplicationLogic.Services;
using BusCompanyManagementApplication.Models.Buses;
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
        public ActionResult Index()
        {
            try
            {
                var buses = busesService.GetBuses();

                return View(new BusViewModel { Buses = buses });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received");
            }
        }

        
        [HttpGet]
        public IActionResult AddBus()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DeleteBus()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpdateBus()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBus([FromForm]AddBusViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            busesService.AddBus("b9f7ba98-7f0a-4201-89ae-ae8195d869ee", 
                            model.BusBrand, 
                            model.TotalSeats);
            return Redirect(Url.Action("Index", "Bus"));

        }

        [HttpPost]
        public IActionResult DeleteBus(Guid id)
        {
            busesService.DeleteBus(id);
            return Redirect(Url.Action("Index", "Bus"));
        }

        [HttpPost]
        public IActionResult UpdateBus([FromForm]UpdateBusViewModel model, Guid id)
        {
            busesService.UpdateBus(id, model.BusBrand, model.TotalSeats);
            return Redirect(Url.Action("Index", "Bus"));
        }


    }
}