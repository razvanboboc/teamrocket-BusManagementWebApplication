using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BusCompanyManagementApplication
{
    public class Program
    {

        //public static void InitializeRoles(RoleManager<IdentityRole> roleManager)
        //{
        //    var adminExists = roleManager.RoleExistsAsync("Administrator")
        //                .GetAwaiter()
        //                .GetResult();

        //    if (!adminExists)
        //    {
        //        roleManager.CreateAsync(new IdentityRole("Administrator"))
        //                    .GetAwaiter()
        //                    .GetResult();
        //    }

        //    var userExists = roleManager.RoleExistsAsync("User")
        //                .GetAwaiter()
        //                .GetResult();

        //    if (!userExists)
        //    {
        //        roleManager.CreateAsync(new IdentityRole("User"))
        //                    .GetAwaiter()
        //                    .GetResult();
        //    }
        //}

        //public static void InitializeAdminUsers(UserManager<IdentityUser> userManager)
        //{
        //    //var adminUser = userManager.FindByEmailAsync("admin@admin.com")
        //    //                            .GetAwaiter()
        //    //                            .GetResult();
        //    IdentityUser admin = new IdentityUser
        //    {
        //        UserName = "admin@gmail.com",
        //        Email = "admin@gmail.com",
        //        EmailConfirmed = true
        //    };
        //    userManager.CreateAsync(admin, "P@ssw0rd").Wait();
        //    // if (adminUser != null)
        //    // {
        //    var result = userManager.AddToRoleAsync(admin, "Administrator")
        //                    .GetAwaiter()
        //                    .GetResult();


        //  //  }
        //}

        //public static void Main(string[] args)
        //{
        //    var host = CreateHostBuilder(args).Build();
        //    using (var scope = host.Services.CreateScope())
        //    {
        //        var services = scope.ServiceProvider;
        //        var roleManager = services.GetService<RoleManager<IdentityRole>>();
        //        var userManager = services.GetService<UserManager<IdentityUser>>();
        //        InitializeRoles(roleManager);
        //        InitializeAdminUsers(userManager);
        //    }

        //    host.Run();
        //}
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
