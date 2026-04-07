using Microsoft.EntityFrameworkCore;
using PhotoPortfolia.Data;
using PhotoPortfolia.Models;
using PhotoPortfolia.ViewModels;



namespace PhotoPortfolia.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly ApplicationDbContext _context;

        public AlbumService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AlbumInfoViewModel>> GetAllAlbumsAsync()
        {
            return await _context.Albums
                .Select(a => new AlbumInfoViewModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    CategoryName = a.Category.Name,
                    PhotosCount = a.Photos.Count
                })
                .ToListAsync();
        }

        public async Task CreateAlbumAsync(AlbumFormModel model)
        {
            var album = new Album
            {
                Title = model.Title,
                Description = model.Description,
                CategoryId = model.CategoryId,
                CreatedOn = DateTime.Now
            };

            await _context.Albums.AddAsync(album);
            await _context.SaveChangesAsync();
        }

        public async Task<AlbumFormModel> GetAlbumFormModelAsync(int? id = null)
        {
            var categories = await _context.Categories
                .Select(c => new CategoryViewModel { Id = c.Id, Name = c.Name })
                .ToListAsync();

            if (id == null)
            {
                return new AlbumFormModel { Categories = categories };
            }

            var album = await _context.Albums.FindAsync(id);
            if (album == null) return null!;

            return new AlbumFormModel
            {
                Id = album.Id,
                Title = album.Title,
                Description = album.Description,
                CategoryId = album.CategoryId,
                Categories = categories
            };
        }
        public async Task EditAlbumAsync(AlbumFormModel model)
        {
            var album = await _context.Albums.FindAsync(model.Id);

            if (album != null)
            {
                album.Title = model.Title;
                album.Description = model.Description;
                album.CategoryId = model.CategoryId;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAlbumAsync(int id)
        {
            var album = await _context.Albums.FindAsync(id);

            if (album != null)
            {
                _context.Albums.Remove(album);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> ExistsAsync(int id) => await _context.Albums.AnyAsync(a => a.Id == id);
    }
}
