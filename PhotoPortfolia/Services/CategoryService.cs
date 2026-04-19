using Microsoft.EntityFrameworkCore;
using PhotoPortfolia.Data;
using PhotoPortfolia.Models;
using PhotoPortfolia.ViewModels;

namespace PhotoPortfolia.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync()
        {
            return await _context.Categories
                .Select(c => new CategoryViewModel { Id = c.Id, Name = c.Name })
                .ToListAsync();
        }

        public async Task CreateCategoryAsync(CategoryViewModel model)
        {
            var category = new Category { Name = model.Name };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<CategoryViewModel?> GetByIdAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return null;

            return new CategoryViewModel { Id = category.Id, Name = category.Name };
        }

        public async Task EditCategoryAsync(CategoryViewModel model)
        {
            var category = await _context.Categories.FindAsync(model.Id);
            if (category != null)
            {
                category.Name = model.Name;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<AdminDashboardViewModel> GetDashboardStatsAsync()
        {
            return new AdminDashboardViewModel
            {
                TotalAlbums = await _context.Albums.CountAsync(),
                TotalPhotos = await _context.Photos.CountAsync(),
                TotalComments = await _context.Comments.CountAsync(),
                CategoryStats = await _context.Categories
                    .Select(c => new CategoryStatViewModel
                    {
                        CategoryName = c.Name,
                        AlbumCount = c.Albums.Count
                    }).ToListAsync()
            };
        }
    }
}

