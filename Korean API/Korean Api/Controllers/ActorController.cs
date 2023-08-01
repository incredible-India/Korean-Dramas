using Korean_Api.Interface;
using Korean_Api.Middleware;
using Korean_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;

namespace Korean_Api.Controllers
{
    [Route("api/actor")]
    [ApiController]
    [ApiKeyAuthetication]
    public class ActorController : ControllerBase
    {
        private readonly IActor _actor;
        public ActorController(IActor actor)
        {
            _actor = actor;
        }

        #region POST
        //New Actor Registration
        [HttpPost("NewActor")]
        public IActionResult CreateNewActor([FromBody] LeadActors actor)
        {
            var lead = _actor.NewActor(actor);
            return Ok(lead);
        }

        //To add movies for actor
        [HttpPost("AddMovies")]
        public IActionResult AddMovies([FromBody] TempMovies temp )
        {
          Movies m =   _actor.AddMovies(temp);
            TempMovies tempMovies = new TempMovies()
            {
                ActorId = m.ActorId,
                movies =  m.movies.Split(",").ToList(),
            };
            return Ok(tempMovies);
        }

        //Add dramas of actor
        [HttpPost("AddDramas")]
        public IActionResult AddDramas([FromBody] TempDramas temp)
        {
            Dramas dr = _actor.AddDramas(temp);
            TempDramas tempDramas = new TempDramas()
            {
                ActorId = dr.ActorId,
                DramaName = dr.DramaName.Split(",").ToList(),
            };
            return Ok(tempDramas);
        }

        //Add details about actor
        [HttpPost("AddDetails")]
        public IActionResult AddDetails([FromBody] Details det)
        {
            Details d = _actor.AddDetailsOfActor(det);
            return Ok(d);
        }

        //add tvshows of actor
        [HttpPost("AddShows")]
        public IActionResult AddShows([FromBody] TempShows tempShows)
        {
            TVShows show = _actor.AddTvShows(tempShows);
            TempShows temp = new TempShows()
            {
                ActorId = show.ActorId,
                TvShows = show.TvShows.Split(",").ToList(),
            };
            return Ok(temp);
        }

        //To show top shows(movies,drama & tvshows)
        [HttpPost("TopShows")]
        public IActionResult TopShows([FromBody] TopMovies shows)
        {
            TopMovies top = _actor.AddTopShows(shows);
            return Ok(top);
        }

        #endregion

        #region GET
        //Get actor details by id
        [HttpGet("GetActor/{actorId:int}")]
        public IActionResult GetActor([FromRoute] int actorId)
        {
            var ac = _actor.GetActorById(actorId);
            if (ac == null)
            {
                return Content("Actor entered not found..");

            }
            return Ok(ac);
        }
        //Get details of all actors
        [HttpGet("GetAllActors")]
        public IActionResult GetAllActorsList()
        {
            var l = _actor.GetAllActors();
            if (l.Count !=0)
            {
                return Ok(l);
            }
            return Content("No actors found...");
        }

        //Get all movies by id
        [HttpGet("GetAllMovies/{id:int}")]
        public IActionResult GetAllMovies([FromRoute] int id)
        {
            var list = _actor.GetAllMoviesByActorId(id);
            return Ok(list);
        }

        //Get all movies,drama and shows list
        [HttpGet("GetAllTopShows")]
        public IActionResult GetAllTopShows()
        {
            var list = _actor.GetAllTopMovies();
            return Ok(list);
        }
        #endregion

     #region Delete
        //Delete actor details by id
        [HttpDelete("DeleteActor/{actorId:int}")]
        public IActionResult DeleteActor([FromRoute] int actorId)
        {
            var del = _actor.DeleteActorById(actorId);
            if (del == 1)
            {
                return Content("Actor deleted successfully..");
            }
            return Content("Something went wrong..");
        }
        #endregion

        //Update actor
        [HttpPut("UpdateActor/{actorId:int}")]
        public IActionResult UpdateActor([FromRoute]int actorId, [FromBody] LeadActors actor)
        {
            var upd = _actor.UpdateActorInfo(actorId, actor);
            if (upd != 1)
            {
                return Content("Actor details cannot be updated..");
            }
            else
            {
                LeadActors ac = _actor.GetActorById(actorId);
                return Ok(ac);
            }
        }
    }
}

