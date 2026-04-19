using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace PhotoPortfolia.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAdminUser(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            if (!await roleManager.RoleExistsAsync("Administrator"))
            {
                await roleManager.CreateAsync(new IdentityRole("Administrator"));
            }

            string adminEmail = "marielka23@gmail.com";
            var user = await userManager.FindByEmailAsync(adminEmail);

            if (user != null)
            {
                if (!await userManager.IsInRoleAsync(user, "Administrator"))
                {
                    await userManager.AddToRoleAsync(user, "Administrator");
                }
            }
        }
    }
}

