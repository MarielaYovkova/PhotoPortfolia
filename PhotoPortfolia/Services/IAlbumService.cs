using PhotoPortfolia.ViewModels;

namespace PhotoPortfolia.Services
{
    public interface IAlbumService
    {
        Task<IEnumerable<AlbumInfoViewModel>> GetAllAlbumsAsync(string? searchString = null);
        Task<AlbumFormModel> GetAlbumFormModelAsync(int? id = null);
        Task CreateAlbumAsync(AlbumFormModel model);
        Task EditAlbumAsync(AlbumFormModel model);
        Task DeleteAlbumAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<AlbumDetailsViewModel> GetAlbumDetailsAsync(int albumId);
    }
}
