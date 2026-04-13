using Microsoft.EntityFrameworkCore;
using PhotoPortfolia.Data;
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
    }
}
