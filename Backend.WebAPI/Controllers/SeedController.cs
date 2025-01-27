using Microsoft.AspNetCore.Mvc;

namespace Backend.WebAPI.Controllers
{
    public class SeedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
