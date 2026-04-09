using PhotoPortfolia.Data;
using PhotoPortfolia.Models;

namespace PhotoPortfolia.Services
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _context;

        public CommentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddCommentAsync(int albumId, string userId, string content)
        {
            var comment = new Comment
            {
                AlbumId = albumId,
                AuthorId = userId,
                Content = content,
                CreatedOn = DateTime.UtcNow
            };

            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(int commentId, string userId, bool isAdmin)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if (comment != null && (comment.AuthorId == userId || isAdmin))
            {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
