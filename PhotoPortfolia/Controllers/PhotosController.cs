using Microsoft.AspNetCore.Mvc;
using PhotoPortfolia.Services;
using PhotoPortfolia.ViewModels;

namespace PhotoPortfolia.Controllers
{
    public class PhotosController : Controller
    {
        private readonly IPhotoService _photoService;
        private readonly IAlbumService _albumService;

        public PhotosController(IPhotoService photoService, IAlbumService albumService)
        {
            _photoService = photoService;
            _albumService = albumService;
        }

        public async Task<IActionResult> AlbumPhotos(int albumId, string searchTerm, int page = 1)
        {
            const int pageSize = 6;
            var album = await _albumService.GetAlbumDetailsAsync(albumId);
            if (album == null) return NotFound();

            var (photos, totalCount) = await _photoService.GetPhotosPagedAsync(albumId, searchTerm, page, pageSize);

            ViewBag.AlbumTitle = album.Title;
            ViewBag.AlbumId = albumId;
            ViewBag.SearchTerm = searchTerm;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            return View(photos);
        }
    }
}