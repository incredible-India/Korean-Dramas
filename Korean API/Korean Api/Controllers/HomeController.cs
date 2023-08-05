using Microsoft.AspNetCore.Mvc;

namespace Korean_Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //adding the Actor
        public IActionResult AddActor()
        {
            return View();
        }
    }
}
