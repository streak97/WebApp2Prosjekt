using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApp2Prosjekt.Data;

namespace WebApp2Prosjekt.Models
{
    public static class Seeding
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration Configuration)
        {
            //adding customs roles
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            string[] roleNames = { "Administrator", "Developer", "Client", "Freelancer" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                // creating the roles and seeding them to the database
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Password set for all test accounts
            var passwd = "#123QWEasd";

            // Admin
            var admin = new IdentityUser { UserName = "Admin@test.no", EmailConfirmed = true };
            if (UserManager.FindByNameAsync("Admin@test.no") == null)
            {
                UserManager.CreateAsync(admin, passwd).Wait();
                await UserManager.AddToRoleAsync(admin, "Administrator");
            }

            // Developers
            for (int i = 0; i < 9; i++)
            {
                var temp = new IdentityUser { UserName = "developer" + i + "@test.no", EmailConfirmed = true };
                if (UserManager.FindByNameAsync(temp.UserName) == null)
                {
                    UserManager.CreateAsync(temp, passwd).Wait();
                    await UserManager.AddToRoleAsync(temp, "Developer");
                }
            }

            // Clients
            for (int i = 0; i < 9; i++)
            {
                var temp = new IdentityUser { UserName = "client" + i + "@test.no", EmailConfirmed = true };
                if (UserManager.FindByNameAsync(temp.UserName) == null)
                {
                    UserManager.CreateAsync(temp, passwd).Wait();
                    await UserManager.AddToRoleAsync(temp, "Client");
                }
            }

            // Freelancer
            for (int i = 0; i < 9; i++)
            {
                var temp = new IdentityUser { UserName = "free" + i + "@test.no", EmailConfirmed = true };
                if (UserManager.FindByNameAsync(temp.UserName) == null)
                {
                    UserManager.CreateAsync(temp, passwd).Wait();
                    await UserManager.AddToRoleAsync(temp, "Freelancer");
                }
            }

            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))

                if (!context.SpecialityFields.Any())
                {
                    context.SpecialityFields.AddRange(
                        new SpecialityField { Type = "Web" },
                        new SpecialityField { Type = "System" },
                        new SpecialityField { Type = "Active Directory" },
                        new SpecialityField { Type = "Artificial Intelligence" },
                        new SpecialityField { Type = "Smelly Code" },
                        new SpecialityField { Type = "Database" }
                        );

                    context.SaveChanges();
                }
        }
    }
}
