using CarRentwithDB.Data;
using JokesApp.Data.Enum;
using JokesApp.Models;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace JokesApp.Data
{
    public class Seed
    {
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "pierwszyAdmin@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = adminUserEmail,
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        Name = "Jan",
                        Surname = "Pierwszy",
                        Phone = "123456789",
                        UserType = UserType.Admin,
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string userUserEmail = "pierwszyKlient@gmail.com";

                var userUser = await userManager.FindByEmailAsync(userUserEmail);
                if (userUser == null)
                {
                    var newUserUser = new AppUser()
                    {
                        UserName = userUserEmail,
                        Email = userUserEmail,
                        EmailConfirmed = true,
                        Name = "Adam",
                        Surname = "Pierwszy",
                        Phone = "987654321",
                        UserType = UserType.User

                    };
                    await userManager.CreateAsync(newUserUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newUserUser, UserRoles.User);
                }
            }
        }

    }
}
