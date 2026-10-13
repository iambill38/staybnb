using Microsoft.AspNetCore.Identity;
using Staybnb.Models;

namespace Staybnb.Seeds
{
    public class RoleSeeder
    {
        public static async Task SeedRolesAndAdminAsync(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            // Define the roles
            var roles = new[] { "Guest", "Host", "Admin", "SuperAdmin" };

            // Create roles if they don't exist
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Create default SuperAdmin user
            var superAdminEmail = "superadmin@staybnb.com";
            var superAdminUser = await userManager.FindByEmailAsync(superAdminEmail);

            if (superAdminUser == null)
            {
                var newSuperAdmin = new User
                {
                    UserName = "superadmin",
                    Email = superAdminEmail,
                    FullName = "Super Administrator",
                    EmailConfirmed = true,
                    IsActive = true,
                    CurrentRole = "SuperAdmin"
                };

                var result = await userManager.CreateAsync(newSuperAdmin, "SuperAdmin@123");

                if (result.Succeeded)
                {
                    // Assign SuperAdmin role
                    await userManager.AddToRoleAsync(newSuperAdmin, "SuperAdmin");
                }
            }
        }
    }
}