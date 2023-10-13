using LibraryApp.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace LibraryApp.Seed
{
    public class Seed
    {
        public static async Task SeedUsers(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var roles = new List<AppRole>
            {
                new AppRole { Name = "Librarian" },
                new AppRole { Name = "Visitor" }
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            
        }

    }
}

