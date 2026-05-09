using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PhotoPortfolia.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public abstract class AdminBaseController : Controller
    {

        protected void SuccessMessage(string message)
        {
            TempData["SuccessMessage"] = message;
        }

        protected void ErrorMessage(string message)
        {
            TempData["ErrorMessage"] = message;
        }


        protected string FormatAdminTitle(string action)
        {
            return $"Admin Panel - {action}";
        }
    }
}
