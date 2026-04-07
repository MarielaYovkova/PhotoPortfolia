using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PhotoPortfolia.Services;
using PhotoPortfolia.ViewModels;

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
}