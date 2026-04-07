using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PhotoPortfolia.Services;
using PhotoPortfolia.ViewModels;

namespace PhotoPortfolia.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumService _albumService;

        public AlbumsController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        public async Task<IActionResult> Index()
        {
            var albums = await _albumService.GetAllAlbumsAsync();
            return View(albums);
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            var model = await _albumService.GetAlbumFormModelAsync();
            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AlbumFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = (await _albumService.GetAlbumFormModelAsync()).Categories;
                return View(model);
            }

            await _albumService.CreateAlbumAsync(model);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _albumService.GetAlbumFormModelAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AlbumFormModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                model.Categories = (await _albumService.GetAlbumFormModelAsync()).Categories;
                return View(model);
            }

            await _albumService.EditAlbumAsync(model);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var albums = await _albumService.GetAllAlbumsAsync();
            var model = albums.FirstOrDefault(a => a.Id == id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!await _albumService.ExistsAsync(id))
            {
                return NotFound();
            }

            await _albumService.DeleteAlbumAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}