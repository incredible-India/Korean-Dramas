using Korean_Api.Interface;
using Korean_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;

namespace Korean_Api.Controllers
{
    [Route("api/actor")]
    [ApiController]
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

