using Korean_Api.Implemantaion;
using Korean_Api.Interface;
using Korean_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Korean_Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsers _user;
        public UserController(IUsers user)
        {
            _user = user;
        }

        #region Post

        //NewUser Registration

        [HttpPost("newuser")]
        public IActionResult NewUserRegistration([FromBody] Users user)
        {
            Dictionary<string,string> status = _user.NewUserRegistration(user);

            return Ok(status);
        }

        #endregion


    }
}
