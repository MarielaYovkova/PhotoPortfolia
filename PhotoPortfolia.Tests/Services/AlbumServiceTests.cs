using Microsoft.EntityFrameworkCore;
using PhotoPortfolia.Data;
using PhotoPortfolia.Models;
using PhotoPortfolia.Services;
using Xunit;

namespace PhotoPortfolia.Tests.Services
{
    public class AlbumServiceTests
    {
        private DbContextOptions<ApplicationDbContext> _options;

        public AlbumServiceTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public async Task GetAlbumDetailsAsync_ShouldReturnCorrectData_WhenAlbumExists()
        {
            // Arrange
            using var context = new ApplicationDbContext(_options);
            var album = new Album
            {
                Id = 1,
                Title = "Nature",
                Description = "Beautiful nature",
                Photos = new List<Photo>
                {
                    new Photo { Id = 1, ImageUrl = "test.jpg", Caption = "Trees" }
                }
            };
            context.Albums.Add(album);
            await context.SaveChangesAsync();

            var service = new AlbumService(context);

            // Act
            var result = await service.GetAlbumDetailsAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Nature", result.Title);
            Assert.Single(result.Photos);
            Assert.Equal("Trees", result.Photos.First().Caption);
        }

        [Fact]
        public async Task GetAlbumDetailsAsync_ShouldReturnNull_WhenAlbumDoesNotExist()
        {
            // Arrange
            using var context = new ApplicationDbContext(_options);
            var service = new AlbumService(context);

            // Act
            var result = await service.GetAlbumDetailsAsync(999);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetAllAlbumsAsync_ShouldFilterBySearchString()
        {
            // Arrange
            using var context = new ApplicationDbContext(_options);

            var category = new Category { Id = 1, Name = "TestCategory" };
            context.Categories.Add(category);

            context.Albums.AddRange(new List<Album>
            {
                 new Album { Id = 10, Title = "Summer Vibes", Description = "Test", CategoryId = 1 },
                 new Album { Id = 11, Title = "Winter Wonderland", Description = "Test", CategoryId = 1 }
            });
            await context.SaveChangesAsync();

            var service = new AlbumService(context);

            // Act
            var result = await service.GetAllAlbumsAsync("Summer");

            // Assert
            Assert.Single(result);
            Assert.Equal("Summer Vibes", result.First().Title);
        }
    }
}

