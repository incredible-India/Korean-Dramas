using Korean_Api.Interface;
using Korean_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Korean_Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly IActor _actor;
        private readonly IUsers _user;

        public HomeController(IActor actor,IUsers users)
        {
          this._actor  =    actor;
            this._user = users;
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

        //list of the user

        public IActionResult UserList()
        {
            var a = _user.GetUsers();
            
            return View(a);

        }

        public IActionResult ActorList()
        {
            var a = _actor.GetAllActors();
            return View(a);
        }
        public IActionResult DeleteActor(int id) 
        {
            _actor.DeleteActorById(id);
            return RedirectToAction("ActorList");
        }
        public IActionResult ActorDetails(int id) 
        {
            var a = _actor.GetDetailsById(id);
            return View(a);
        }
        public IActionResult UpdateActor(int id) 
        {
            var a =_actor.GetActorById(id);
            return View(a);
        }
        [HttpPost]
        public IActionResult UpdateActor(int id,LeadActors leadActors)
        {
            _actor.UpdateActorInfo(id, leadActors);
            return RedirectToAction("ActorList");

        }

        public IActionResult AddDramas()
        {
            return View();
        }


        //add movies
        [HttpPost]
        public IActionResult AddDramas(TempDramas temp)
        {
            _actor.AddDramas(temp);
            return View();
        }

        public IActionResult GetAlltopShow() {
            var a =_actor.GetAllTopMovies();
            return View(a);
        }
    }
}
