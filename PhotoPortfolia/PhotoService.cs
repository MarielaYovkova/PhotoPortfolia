using PhotoPortfolia.ViewModels;
using PhotoPortfolia.Services; // Add this using directive if IPhotoService is in this namespace

// Ensure this class implements the IPhotoService interface
public class PhotoService : IPhotoService
{
    // Implement all members of IPhotoService here
    public async Task<(IEnumerable<PhotoViewModel> Photos, int TotalCount)> GetPhotosPagedAsync(int albumId, string searchTerm, int page, int pageSize)
    {
        // Implementation here
        throw new NotImplementedException();
    }
}