using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PhotoPortfolia.Models;
using PhotoPortfolia.Services;
using PhotoPortfolia.ViewModels;

namespace PhotoPortfolia.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAlbumService _albumService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IAlbumService albumService, ILogger<HomeController> logger)
        {
            _albumService = albumService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var albums = await _albumService.GetAllAlbumsAsync();

                var latestAlbums = albums
                    .OrderByDescending(a => a.Id)
                    .Take(3)
                    .ToList();

                return View(latestAlbums);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading latest albums for Home Index");
                return View(new List<AlbumInfoViewModel>());
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("Home/Error/{statusCode}")]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 404)
            {
                return View("NotFound");
            }

            return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}