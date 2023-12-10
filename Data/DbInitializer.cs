using Microsoft.AspNetCore.Identity;

namespace Net_Frameworks.Data
{
    public static class DbInitializer
    {
        public static void Initialize(Net_FrameworksContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            if (!context.Roles.Any())
            {
                roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
                roleManager.CreateAsync(new IdentityRole("User")).GetAwaiter().GetResult();
            }

            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var adminUser = new IdentityUser
                {
                    UserName = "admin",
                    Email = "admin@example.com"
                };

                IdentityResult result = userManager.CreateAsync(adminUser, "Password123!").GetAwaiter().GetResult();

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(adminUser, "Admin").GetAwaiter().GetResult();
                }
            }

            // Voeg seeding data toe voor Categories, Products en ProductCategories
        }
    }
}
