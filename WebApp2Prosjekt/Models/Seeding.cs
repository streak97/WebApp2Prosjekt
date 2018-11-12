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
                //Adds roles and default users
                if (!context.Users.Any())
                {

                    var roleManager = app.GetService<RoleManager<IdentityRole>>();
                    var UserManager = app.GetService<UserManager<IdentityUser>>();

                    var passwd = "#123QWEasd";

                    var admin = new IdentityUser { UserName = "Admin" };
                    UserManager.CreateAsync(admin, passwd).Wait();

                    var dev0 = new IdentityUser { UserName = "developer0@test.no" };
                    UserManager.CreateAsync(dev0, passwd).Wait();
                    var dev1 = new IdentityUser { UserName = "developer1@test.no" };
                    UserManager.CreateAsync(dev1, passwd).Wait();
                    var dev2 = new IdentityUser { UserName = "developer2@test.no" };
                    UserManager.CreateAsync(dev2, passwd).Wait();
                    var dev3 = new IdentityUser { UserName = "developer3@test.no" };
                    UserManager.CreateAsync(dev3, passwd).Wait();
                    var dev4 = new IdentityUser { UserName = "developer4@test.no" };
                    UserManager.CreateAsync(dev4, passwd).Wait();
                    var dev5 = new IdentityUser { UserName = "developer5@test.no" };
                    UserManager.CreateAsync(dev5, passwd).Wait();
                    var dev6 = new IdentityUser { UserName = "developer6@test.no" };
                    UserManager.CreateAsync(dev6, passwd).Wait();
                    var dev7 = new IdentityUser { UserName = "developer7@test.no" };
                    UserManager.CreateAsync(dev7, passwd).Wait();
                    var dev8 = new IdentityUser { UserName = "developer8@test.no" };
                    UserManager.CreateAsync(dev8, passwd).Wait();
                    var dev9 = new IdentityUser { UserName = "developer9@test.no" };
                    UserManager.CreateAsync(dev9, passwd).Wait();

                    roleManager.CreateAsync(new IdentityRole("Administrator")).Wait();
                    roleManager.CreateAsync(new IdentityRole("Developer")).Wait();
                    roleManager.CreateAsync(new IdentityRole("Client")).Wait();
                    roleManager.CreateAsync(new IdentityRole("Freelancer")).Wait();

                    UserManager.AddToRoleAsync(admin, "Administrator").Wait();
                    UserManager.AddToRoleAsync(dev0, "Developer").Wait();
                    UserManager.AddToRoleAsync(dev1, "Developer").Wait();
                    UserManager.AddToRoleAsync(dev2, "Developer").Wait();
                    UserManager.AddToRoleAsync(dev3, "Developer").Wait();
                    UserManager.AddToRoleAsync(dev4, "Developer").Wait();
                    UserManager.AddToRoleAsync(dev5, "Developer").Wait();
                    UserManager.AddToRoleAsync(dev6, "Developer").Wait();
                    UserManager.AddToRoleAsync(dev7, "Developer").Wait();
                    UserManager.AddToRoleAsync(dev8, "Developer").Wait();
                    UserManager.AddToRoleAsync(dev9, "Developer").Wait();
                }

                if (!context.SpecialityFields.Any())
                {
                    context.SpecialityFields.AddRange(
                        new SpecialityField { Type = "Web" },
                        new SpecialityField { Type = "System" },
                        new SpecialityField { Type = "Active Directory" },
                        new SpecialityField { Type = "Artificial Intelligence" },
                        new SpecialityField { Type = "Smelly Code" },
                        new SpecialityField { Type = "Database"}
                        );

                    context.SaveChanges();
                }
            }


        }
    }
}
