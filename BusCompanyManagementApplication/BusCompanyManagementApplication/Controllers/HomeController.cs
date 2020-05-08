using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BusCompanyManagementApplication.Models;
using Microsoft.AspNetCore.Authorization;
using BusCompanyManagementApplication.Models.AnnouncementModel;
using BusCompanyManagement.ApplicationLogic.DataModel;
using BusCompanyManagement.ApplicationLogic.Services;

namespace BusCompanyManagementApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AnnouncementsService announcementsService;
        public HomeController(ILogger<HomeController> logger, AnnouncementsService announcementsService)
        {
            _logger = logger;
            this.announcementsService = announcementsService;
        }

        //public IActionResult Index(IEnumerable<Announcement> announcements)
        //{

        //    announcements = announcementsService.GetAll();

        //    if (announcements == null)
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        return View(new AnnouncementViewModel { Announcements = announcements });
        //    }
        //}

        public ActionResult Index()
        {
            try
            {
                var announcements = announcementsService.GetAll();

                return View(new AnnouncementViewModel { Announcements = announcements });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received");
            }
        }
    
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
