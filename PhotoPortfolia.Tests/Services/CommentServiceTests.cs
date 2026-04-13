using Microsoft.EntityFrameworkCore;
using PhotoPortfolia.Data;
using PhotoPortfolia.Models;
using PhotoPortfolia.Services;
using Xunit;

namespace PhotoPortfolia.Tests.Services
{
    public class CommentServiceTests
    {
        private DbContextOptions<ApplicationDbContext> _options;

        public CommentServiceTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public async Task AddCommentAsync_ShouldSaveCorrectly()
        {
            using var context = new ApplicationDbContext(_options);
            var service = new CommentService(context);

            await service.AddCommentAsync(1, "user-id-123", "Cool photo!");

            var comment = await context.Comments.FirstOrDefaultAsync();
            Assert.NotNull(comment);
            Assert.Equal("Cool photo!", comment.Content);
            Assert.Equal("user-id-123", comment.AuthorId);
        }

        [Fact]
        public async Task DeleteCommentAsync_ShouldNotDelete_IfUserIsNotAuthor()
        {
            using var context = new ApplicationDbContext(_options);
            var comment = new Comment { Id = 10, Content = "Stay", AuthorId = "AuthorId", AlbumId = 1 };
            context.Comments.Add(comment);
            await context.SaveChangesAsync();

            var service = new CommentService(context);

            await service.DeleteCommentAsync(10, "WrongUser", false);

            // Assert
            var exists = await context.Comments.AnyAsync(c => c.Id == 10);
            Assert.True(exists);
        }
    }
}