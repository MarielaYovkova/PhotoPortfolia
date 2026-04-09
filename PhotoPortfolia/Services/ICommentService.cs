namespace PhotoPortfolia.Services
{
    public interface ICommentService
    {
        Task AddCommentAsync(int albumId, string userId, string content);
        Task DeleteCommentAsync(int commentId, string userId, bool isAdmin);
    }
}
