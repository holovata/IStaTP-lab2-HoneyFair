using Microsoft.AspNetCore.Mvc;

namespace holovataLab2HoneyFair.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Hello world!";
            return View("Index");
        }
    }
}
