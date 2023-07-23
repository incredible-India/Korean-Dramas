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
        public IActionResult CreateNewActor([FromBody]LeadActors actor)
        {
            var lead = _actor.NewActor(actor);
            return Ok(lead);
        }


        #endregion
    }
}