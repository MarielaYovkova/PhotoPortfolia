using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhotoPortfolia.Models;

public class PhotosController : Controller
{
    private readonly ApplicationDbContext _context;

    public PhotosController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> AlbumPhotos(int albumId)
    {
        var album = await _context.Albums
            .Include(a => a.Photos)
            .FirstOrDefaultAsync(a => a.Id == albumId);

        if (album == null) return NotFound();

        return View(album);
    }
}
