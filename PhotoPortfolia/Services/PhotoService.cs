using Microsoft.EntityFrameworkCore;
using PhotoPortfolia.Data;
using PhotoPortfolia.ViewModels;

namespace PhotoPortfolia.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly ApplicationDbContext _context;

        public PhotoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<PhotoViewModel> Photos, int TotalCount)> GetPhotosPagedAsync(int albumId, string searchTerm, int page, int pageSize)
        {
            // 1. Започваме от всички снимки в албума
            var query = _context.Photos
                .Where(p => p.AlbumId == albumId)
                .AsQueryable();

            // 2. Филтриране (Търсене) - Забележка на лектора
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(p => p.Title.Contains(searchTerm) ||
                                       (p.Description != null && p.Description.Contains(searchTerm)));
            }

            // 3. Общ брой за пагинацията
            int totalCount = await query.CountAsync();

            // 4. Пагинация (Skip и Take) - Забележка на лектора
            var photos = await query
                .OrderBy(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new PhotoViewModel // Мапване към View Model
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    AlbumId = p.AlbumId
                })
                .ToListAsync();

            return (photos, totalCount);
        }
    }
}