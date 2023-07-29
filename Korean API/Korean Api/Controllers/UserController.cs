using Korean_Api.Implemantaion;
using Korean_Api.Interface;
using Korean_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

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


        //user login
        [HttpPost("login")]

        public IActionResult UserLogin([FromForm] string Email, [FromForm] string Password)
        {
            var isLogin = _user.Login(Email, Password);

            if(isLogin == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(isLogin);
            }
            
        }

        //add fav actors/actress
        [HttpPost("Addfav")]
        public IActionResult Addfav(FavLead favLead) {

            int isAdded = _user.AddfavActor(favLead);
            if(isAdded == 0)
            {
                return Ok("Something went wrong !!!");
            }
            else
            {
                Users u = _user.GetUserById(favLead.ActorId);
                if(u!=null)
                {
                    return Ok(u);
                }
                else
                {
                    return Ok("Something went wrong !!!");
                }
            }
           
         }

        #endregion


        #region Delete
        [HttpDelete("delete/{userID:int}")]
        public IActionResult DeleteUser([FromRoute] int userID)
        {
            int isDeleted = _user.DeleteUserById(userID);
            if(isDeleted == 0) { return Ok("Given id Does not Exist.."); }
            else { return Ok("User Has been deleted Successfully.."); }
           
        }
        #endregion


        #region Get
        [HttpGet("getallusers")]
        public IActionResult GetAllUser()
        {
           var a= _user.GetUsers();
            if(a.Count > 0)
                return Ok(a);
            return Ok("No User Exist");
        }
        #endregion
    }
}
