using Korean_Api.Interface;
using Korean_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Korean_Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly IActor _actor;
        private readonly IUsers _user;
        private readonly IWebHostEnvironment _env;

        public HomeController(IActor actor,IUsers users,IWebHostEnvironment webHostEnvironment)
        {
          this._actor  =    actor;
            this._user = users;
            this._env = webHostEnvironment;
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
        public IActionResult UpdateMovie(int id)
        {
            var a = _actor.GetMovieByID(id);
            return View(a);
        }
        [HttpPost]
        public IActionResult UpdateMovie(int id, Movies movie)
        {
            _actor.UpdateMovie(id, movie);
            return RedirectToAction("GetAllMoviesList");
        }
        //Save image
        public IActionResult SaveImage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SavePostImage()
        {
            try
            {
                //checking whether the requested file exists
                var _uploadedFile = Request.Form.Files;
                foreach (IFormFile source in _uploadedFile)
                {
                    string Filename = source.FileName;
                    string Filepath = GetFilepath(Filename);

                    //checking whether that folder exists or else creating a new one with same name
                    if (!System.IO.Directory.Exists(Filepath))
                    {
                        System.IO.Directory.CreateDirectory(Filepath);
                    }

                    string imagepath = Filepath + "\\image.png";

                    if (System.IO.File.Exists(imagepath)){

                        System.IO.File.Delete(imagepath);
                    }
                    using (FileStream stream = System.IO.File.Create(imagepath))
                    {
                        source.CopyTo(stream);
                    }

                }


            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("SaveImage");
        }
        [NonAction]
        private string GetFilepath(string filename)
        {
            return this._env.WebRootPath +"\\" +filename;
        }
        public IActionResult AddDramas()
        {
            var a = _actor.GetAllActors();
            ViewBag.a = a.ToList();
            return View();
        }


        //add movies
        [HttpPost]
        public IActionResult AddDramas(TempDramas temp)
        {
            _actor.AddDramas(temp);
            return RedirectToAction("AddDramas");
        }
        
        public IActionResult AddMovies()
        {
            var a = _actor.GetAllActors();
            ViewBag.a = a.ToList();
            return View();
        }


        //add movies
        [HttpPost]
        public IActionResult AddMovies(TempMovies temp)
        {
            _actor.AddMovies(temp);
            return RedirectToAction("AddMovies");
        }
        public IActionResult AddShows()
        {
            var a = _actor.GetAllActors();
            ViewBag.a = a.ToList();
            return View();
        }


        //add movies
        [HttpPost]
        public IActionResult AddShows(TempShows temp)
        {
            _actor.AddTvShows(temp);
            return RedirectToAction("AddShows");
        }

        public IActionResult GetAlltopShow() {
            var a =_actor.GetAllTopMovies();
            return View(a);
        }

        public IActionResult GetAllMoviesList()
        {
            var b = _actor.GetAllActors();
            ViewBag.b = b.ToList();
            var a = _actor.GetAllMovies();
            return View(a);
        }
        public IActionResult DeleteMovie(int id) 
        {
            _actor.DeleteMovieById(id);
            return RedirectToAction("GetAllMoviesList");
        }
        public IActionResult GetAllDramasList() 
        {
            var a = _actor.GetAllDramas();
            return View(a);
        }
        public IActionResult DeleteDrama(int id)
        {
            _actor.DeleteDramaId(id);
            return RedirectToAction("GetAllDramasList");
        }
        public IActionResult GetAllShowsList() 
        {
            var s  = _actor.GetAllTvShows();
            return View(s);
        }

        public IActionResult DeleteTvShow(int id)
        {
            _actor.DeleteShowBYID(id);
            return RedirectToAction("GetAllShowsList");
        }
    }
}
