using Korean_Api.Interface;
using Korean_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Korean_Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly IActor _actor;

        public HomeController(IActor actor)
        {
          this._actor  =    actor;
        }
        public IActionResult Index()
        {
            return View();
        }

        //adding the Actor
        public IActionResult AddActor()
        {
            return View();
        }

        [HttpPost]
        //adding the Actor
        public IActionResult AddActor(LeadActors actor)
        {

            var a = _actor.NewActor(actor);
            
            if(a != null)
            {
                TempData["success"] = $"{actor.Name} added successfully..";
            }
            return RedirectToAction("AddActor");
        }


        //adding the user 
        public IActionResult AddUser()
        {
            return View();
        }
    }
}
