using Microsoft.AspNetCore.Mvc;


namespace StoneSafety.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}