using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PhotoPortfolia.Models;
using Microsoft.EntityFrameworkCore;

namespace PhotoPortfolia.Data
{
    public static class DbInitializer
    {

        private const string AdminRole = "Administrator";
        private const string AdminEmail = "marielka23@gmail.com";
        private const string NatureCategory = "Nature";
        private const string PortraitCategory = "Portraits";

        public static async Task SeedData(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();


            if (!await roleManager.RoleExistsAsync(AdminRole))
            {
                await roleManager.CreateAsync(new IdentityRole(AdminRole));
            }


            var adminUser = await userManager.FindByEmailAsync(AdminEmail);
            if (adminUser == null)
            {
                adminUser = new IdentityUser
                {
                    UserName = AdminEmail,
                    Email = AdminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, "Admin123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, AdminRole);
                }
            }


            if (!await context.Categories.AnyAsync())
            {
                var categories = new List<Category>
                {
                    new Category { Name = NatureCategory },
                    new Category { Name = PortraitCategory },
                    new Category { Name = "Weddings" },
                    new Category { Name = "Events" }
                };

                await context.Categories.AddRangeAsync(categories);
                await context.SaveChangesAsync();
            }


            if (!await context.Albums.AnyAsync())
            {
                var category = await context.Categories.FirstOrDefaultAsync(c => c.Name == NatureCategory);
                if (category != null)
                {
                    var defaultAlbum = new Album
                    {
                        Title = "Starting Portfolio",
                        Description = "This is an automatically generated album to showcase the structure.",
                        CategoryId = category.Id
                    };

                    await context.Albums.AddAsync(defaultAlbum);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}