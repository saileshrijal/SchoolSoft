using Microsoft.AspNetCore.Mvc;

namespace SchoolSoft.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
