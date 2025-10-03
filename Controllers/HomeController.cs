using Microsoft.AspNetCore.Mvc;

namespace DisasterAlleviation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
