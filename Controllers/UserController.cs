using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using split_me_backend.Models;
using System.Collections;

namespace split_me_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        List<User> users; // temp
        public UserController()
        {
            users = new List<User>();  // temp array till db arrives to test
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User userObj)
        {
            if (userObj == null)
                return BadRequest();

            // logic to check if user exists in db

            // if no user
            if(false)
                return NotFound(new { Message = "User Not Found!" });


            return Ok(new
            {
                Message = "Login Successful!"
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] User userObj)
        {
            if (userObj == null)
                return BadRequest();

            //logic to add User to db async

            //temp add method
            users.Add(userObj);

            return Ok(new
            {
                Message = "User Registered!",
                Users = users.ToArray()
               
            });
        }
        [HttpGet("getUsers")]
        public async Task<IActionResult> getUsers()
        {
            //temp test method to check existing users
            return Ok(
                new
                {
                    users = this.users.ToArray()
                });
        }
    }
}
