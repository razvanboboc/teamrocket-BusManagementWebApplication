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

    }
}