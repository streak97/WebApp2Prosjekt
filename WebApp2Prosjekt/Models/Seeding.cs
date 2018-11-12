using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp2Prosjekt.Data;

namespace WebApp2Prosjekt.Models
{
    public static class Seeding
    {
        public static void Initialize(IServiceProvider app)
        {
            using (
                var context = new ApplicationDbContext(app.GetRequiredService<DbContextOptions<ApplicationDbContext>>())
                )
            {
                if (!context.Users.Any())
                {

                    var roleManager = app.GetService<RoleManager<IdentityRole>>();
                    var UserManager = app.GetService<UserManager<IdentityUser>>();

                    var passwd = "123qweasd";

                    var admin = new IdentityUser { UserName = "Admin" };
                    UserManager.CreateAsync(admin, passwd);

                    var dev0 = new IdentityUser { UserName = "Developer0" };
                    UserManager.CreateAsync(dev0, passwd);
                    var dev1 = new IdentityUser { UserName = "Developer1" };
                    UserManager.CreateAsync(dev1, passwd);
                    var dev2 = new IdentityUser { UserName = "Developer2" };
                    UserManager.CreateAsync(dev2, passwd);
                    var dev3 = new IdentityUser { UserName = "Developer3" };
                    UserManager.CreateAsync(dev3, passwd);
                    var dev4 = new IdentityUser { UserName = "Developer4" };
                    UserManager.CreateAsync(dev4, passwd);
                    var dev5 = new IdentityUser { UserName = "Developer5" };
                    UserManager.CreateAsync(dev5, passwd);
                    var dev6 = new IdentityUser { UserName = "Developer6" };
                    UserManager.CreateAsync(dev6, passwd);
                    var dev7 = new IdentityUser { UserName = "Developer7" };
                    UserManager.CreateAsync(dev7, passwd);
                    var dev8 = new IdentityUser { UserName = "Developer8" };
                    UserManager.CreateAsync(dev8, passwd);
                    var dev9 = new IdentityUser { UserName = "Developer9" };
                    UserManager.CreateAsync(dev9, passwd);

                    roleManager.CreateAsync(new IdentityRole("Administrator"));
                    roleManager.CreateAsync(new IdentityRole("Developer"));
                    roleManager.CreateAsync(new IdentityRole("Client"));
                    roleManager.CreateAsync(new IdentityRole("Freelancer"));

                    UserManager.AddToRoleAsync(admin, "Administrator");
                    UserManager.AddToRoleAsync(dev0, "Developer");
                    UserManager.AddToRoleAsync(dev1, "Developer");
                    UserManager.AddToRoleAsync(dev2, "Developer");
                    UserManager.AddToRoleAsync(dev3, "Developer");
                    UserManager.AddToRoleAsync(dev4, "Developer");
                    UserManager.AddToRoleAsync(dev5, "Developer");
                    UserManager.AddToRoleAsync(dev6, "Developer");
                    UserManager.AddToRoleAsync(dev7, "Developer");
                    UserManager.AddToRoleAsync(dev8, "Developer");
                    UserManager.AddToRoleAsync(dev9, "Developer");
                }
            }

        }
    }
}
