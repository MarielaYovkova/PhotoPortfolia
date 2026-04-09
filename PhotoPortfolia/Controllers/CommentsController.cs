using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using PhotoPortfolia.Services;

namespace PhotoPortfolia.Controllers
{
    [Authorize]
    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(int albumId, string content)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrWhiteSpace(content) || userId == null)
            {
                return RedirectToAction("Index", "Albums");
            }

            await _commentService.AddCommentAsync(albumId, userId, content);
            return RedirectToAction("Index", "Albums");
        }
    }
}

