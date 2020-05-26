using BusCompanyManagementApplication.Models.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusCompanyManagementApplication.Data
{
    public static class DbSeeder
    {
        public static void SeedDb(UserManager<ApplicationUser> userManager)
        {
            if (!userManager.Users.Any(u => u.UserName == "user@gmail.com"))
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "user@gmail.com",
                    Email = "user@gmail.com"
                };
                userManager.CreateAsync(user, "R@zvanVerde66").Wait();
                userManager.AddToRoleAsync(user, "User").Wait();
            }

            if (!userManager.Users.Any(u => u.UserName == "admin1@gmail.com"))
            {
                ApplicationUser admin = new ApplicationUser
                {
                    UserName = "admin1@gmail.com",
                    Email = "admin1@gmail.com"
                };
                userManager.CreateAsync(admin, "R@zvanVerde66").Wait();
                userManager.AddToRoleAsync(admin, "Administrator").Wait();
            }

            if (!userManager.Users.Any(u => u.UserName == "admin2@gmail.com"))
            {
                ApplicationUser admin2 = new ApplicationUser
                {
                    UserName = "admin2@gmail.com",
                    Email = "admin2@gmail.com"
                };
                userManager.CreateAsync(admin2, "R@zvanVerde66").Wait();
                userManager.AddToRoleAsync(admin2, "Administrator").Wait();
            }
        }
    }
}
