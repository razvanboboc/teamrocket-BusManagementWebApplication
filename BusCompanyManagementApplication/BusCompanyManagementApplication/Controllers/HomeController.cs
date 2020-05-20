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

        public ActionResult Index()
        {
            try
            {
                var announcements = announcementsService.GetAll();

                List<Announcement> announcementsList = announcements.ToList();

                announcementsList.Sort((x, y) => DateTime.Compare(y.AddedTime, x.AddedTime));

                announcements = announcementsList;

                return View(new AnnouncementViewModel { Announcements = announcements });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received");
            }
        }
        
        [HttpGet]
        public IActionResult ViewAnnouncement([FromRoute]Guid id)
        {
            var announcement = announcementsService.GetAnnouncementById(id);

            return View(new ViewAnnouncementViewModel { Announcement = announcement });
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult AddAnnouncement([FromForm]AddAnnouncementViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }

            announcementsService.AddAnnouncement(model.Title, model.Content);

            return Redirect(Url.Action("Index", "Home"));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Popup()
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
