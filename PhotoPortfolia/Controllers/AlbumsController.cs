using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhotoPortfolia.Models;

public class AlbumsController : Controller
{
    private readonly ApplicationDbContext _context;

    public AlbumsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var albums = await _context.Albums.Include(a => a.Category).ToListAsync();
        return View(albums);
    }

    public IActionResult Create()
    {
        ViewBag.Categories = _context.Categories.ToList();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Album album)
    {
        if (ModelState.IsValid)
        {
            _context.Add(album);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Categories = _context.Categories.ToList();
        return View(album);
    }

   
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var album = await _context.Albums.FindAsync(id);
        if (album == null) return NotFound();

        ViewBag.Categories = _context.Categories.ToList();
        return View(album);
    }

    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Album album)
    {
        if (id != album.Id) return NotFound();

        if (ModelState.IsValid)
        {
            _context.Update(album);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Categories = _context.Categories.ToList();
        return View(album);
    }

    
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var album = await _context.Albums
            .Include(a => a.Category)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (album == null) return NotFound();

        return View(album);
    }

    
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var album = await _context.Albums.FindAsync(id);
        if (album != null)
        {
            _context.Albums.Remove(album);
        }
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
