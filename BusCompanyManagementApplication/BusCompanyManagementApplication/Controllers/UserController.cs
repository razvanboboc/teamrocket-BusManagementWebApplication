using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusCompanyManagement.ApplicationLogic.Services;
using BusCompanyManagementApplication.Models.Users;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusCompanyManagementApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly UsersService usersService;

        public UserController(UsersService usersService)
        {

            this.usersService = usersService;
        }
        public ActionResult Index()
        {
            try
            {
                var users = usersService.GetAll();

                return View(new UserViewModel { Users = users });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received");
            }
        }

        

    }
}