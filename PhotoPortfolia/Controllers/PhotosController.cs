using Microsoft.AspNetCore.Mvc;
using PhotoPortfolia.Services;

public class PhotosController : Controller
{
    private readonly IAlbumService _albumService;

    public PhotosController(IAlbumService albumService)
    {
        _albumService = albumService;
    }

    public async Task<IActionResult> AlbumPhotos(int albumId)
    {
        var model = await _albumService.GetAlbumDetailsAsync(albumId);

        if (model == null) return NotFound();

        return View(model);
    }
}
