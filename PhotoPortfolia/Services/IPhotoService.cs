using PhotoPortfolia.ViewModels;

namespace PhotoPortfolia.Services
{
    public interface IPhotoService
    {
        Task<(IEnumerable<PhotoViewModel> Photos, int TotalCount)> GetPhotosPagedAsync(int albumId, string searchTerm, int page, int pageSize);
    }
}
