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

                    // Password set for all test accounts
                    var passwd = "#123QWEasd";

                    // Admin
                    var admin = new IdentityUser { UserName = "Admin" };
                    UserManager.CreateAsync(admin, passwd).Wait();

                    // Developers
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

                    // Clients
                    var client0 = new IdentityUser { UserName = "client0@test.no" };
                    UserManager.CreateAsync(client0, passwd).Wait();
                    var client1 = new IdentityUser { UserName = "client1@test.no" };
                    UserManager.CreateAsync(client1, passwd).Wait();
                    var client2 = new IdentityUser { UserName = "client2@test.no" };
                    UserManager.CreateAsync(client2, passwd).Wait();
                    var client3 = new IdentityUser { UserName = "client3@test.no" };
                    UserManager.CreateAsync(client3, passwd).Wait();
                    var client4 = new IdentityUser { UserName = "client4@test.no" };
                    UserManager.CreateAsync(client4, passwd).Wait();
                    var client5 = new IdentityUser { UserName = "client5@test.no" };
                    UserManager.CreateAsync(client5, passwd).Wait();
                    var client6 = new IdentityUser { UserName = "client6@test.no" };
                    UserManager.CreateAsync(client6, passwd).Wait();
                    var client7 = new IdentityUser { UserName = "client7@test.no" };
                    UserManager.CreateAsync(client7, passwd).Wait();
                    var client8 = new IdentityUser { UserName = "client8@test.no" };
                    UserManager.CreateAsync(client8, passwd).Wait();
                    var client9 = new IdentityUser { UserName = "client9@test.no" };
                    UserManager.CreateAsync(client9, passwd).Wait();

                    //Freelancer
                    var free0 = new IdentityUser { UserName = "free0@test.no" };
                    UserManager.CreateAsync(free0, passwd).Wait();
                    var free1 = new IdentityUser { UserName = "free1@test.no" };
                    UserManager.CreateAsync(free1, passwd).Wait();
                    var free2 = new IdentityUser { UserName = "free2@test.no" };
                    UserManager.CreateAsync(free2, passwd).Wait();
                    var free3 = new IdentityUser { UserName = "free3@test.no" };
                    UserManager.CreateAsync(free3, passwd).Wait();
                    var free4 = new IdentityUser { UserName = "free4@test.no" };
                    UserManager.CreateAsync(free4, passwd).Wait();
                    var free5 = new IdentityUser { UserName = "free5@test.no" };
                    UserManager.CreateAsync(free5, passwd).Wait();
                    var free6 = new IdentityUser { UserName = "free6@test.no" };
                    UserManager.CreateAsync(free6, passwd).Wait();
                    var free7 = new IdentityUser { UserName = "free7@test.no" };
                    UserManager.CreateAsync(free7, passwd).Wait();
                    var free8 = new IdentityUser { UserName = "free8@test.no" };
                    UserManager.CreateAsync(free8, passwd).Wait();
                    var free9 = new IdentityUser { UserName = "free9@test.no" };
                    UserManager.CreateAsync(free9, passwd).Wait();

                    roleManager.CreateAsync(new IdentityRole("Administrator")).Wait();
                    roleManager.CreateAsync(new IdentityRole("Developer")).Wait();
                    roleManager.CreateAsync(new IdentityRole("Client")).Wait();
                    roleManager.CreateAsync(new IdentityRole("Freelancer")).Wait();

                    // Admin
                    UserManager.AddToRoleAsync(admin, "Administrator").Wait();
                    // Developers
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
                    // Clients
                    UserManager.AddToRoleAsync(client0, "Client").Wait();
                    UserManager.AddToRoleAsync(client1, "Client").Wait();
                    UserManager.AddToRoleAsync(client2, "Client").Wait();
                    UserManager.AddToRoleAsync(client3, "Client").Wait();
                    UserManager.AddToRoleAsync(client4, "Client").Wait();
                    UserManager.AddToRoleAsync(client5, "Client").Wait();
                    UserManager.AddToRoleAsync(client6, "Client").Wait();
                    UserManager.AddToRoleAsync(client7, "Client").Wait();
                    UserManager.AddToRoleAsync(client8, "Client").Wait();
                    UserManager.AddToRoleAsync(client9, "Client").Wait();
                    // Freelancer
                    UserManager.AddToRoleAsync(free0, "Freelancer").Wait();
                    UserManager.AddToRoleAsync(free1, "Freelancer").Wait();
                    UserManager.AddToRoleAsync(free2, "Freelancer").Wait();
                    UserManager.AddToRoleAsync(free3, "Freelancer").Wait();
                    UserManager.AddToRoleAsync(free4, "Freelancer").Wait();
                    UserManager.AddToRoleAsync(free5, "Freelancer").Wait();
                    UserManager.AddToRoleAsync(free6, "Freelancer").Wait();
                    UserManager.AddToRoleAsync(free7, "Freelancer").Wait();
                    UserManager.AddToRoleAsync(free8, "Freelancer").Wait();
                    UserManager.AddToRoleAsync(free9, "Freelancer").Wait();
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
