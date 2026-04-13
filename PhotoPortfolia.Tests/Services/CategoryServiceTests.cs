using Microsoft.EntityFrameworkCore;
using PhotoPortfolia.Data;
using PhotoPortfolia.Models;
using PhotoPortfolia.Services;
using PhotoPortfolia.ViewModels;
using Xunit;

namespace PhotoPortfolia.Tests.Services
{
    public class CategoryServiceTests
    {
        private DbContextOptions<ApplicationDbContext> _options;
        private ApplicationDbContext _context;
        private CategoryService _service;

        public CategoryServiceTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDbContext(_options);
            _service = new CategoryService(_context);
        }

        [Fact]
        public async Task CreateCategoryAsync_ShouldAddCategoryCorrectly()
        {
            // Arrange
            var model = new CategoryViewModel { Name = "Nature" };

            // Act
            await _service.CreateCategoryAsync(model);

            // Assert
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name == "Nature");
            Assert.NotNull(category);
            Assert.Equal("Nature", category.Name);
        }

        [Fact]
        public async Task EditCategoryAsync_ShouldUpdateName()
        {
            // Arrange
            var category = new Category { Name = "Old Name" };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            var editModel = new CategoryViewModel { Id = category.Id, Name = "New Name" };

            // Act
            await _service.EditCategoryAsync(editModel);

            // Assert
            var updated = await _context.Categories.FindAsync(category.Id);
            Assert.Equal("New Name", updated?.Name);
        }

        [Fact]
        public async Task DeleteCategoryAsync_ShouldRemoveFromDatabase()
        {
            // Arrange
            var category = new Category { Name = "To Be Deleted" };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            // Act
            await _service.DeleteCategoryAsync(category.Id);

            // Assert
            var exists = await _context.Categories.AnyAsync(c => c.Id == category.Id);
            Assert.False(exists);
        }
    }
}
