namespace Workify_Backend.Controllers
{ 
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Linq;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [Route("api/user/createuser")]
        [HttpPost]
        public IActionResult CreateUser(Models.User user)
        {
            if(user.Email == null)
            {
                return Problem("Email is needed");
            }
            else if (user.Username == null)
            {
                return Problem("Username is needed");
            }
            else if (user.Password == null)
            {
                return Problem("Password is needed");
            }
            else
            {
                var hashedPassword = Functions.hashing.HashPassword(user.Password);
                using(var dataList = new Database.Database())
                {
                    dataList.Users.Add(new Models.User { Email = user.Email, Password = hashedPassword, Username = user.Username });
                    dataList.SaveChanges();
                }
                return Ok("user Created");
            }

            return Forbid();
        }
        [HttpPost]
        public IActionResult Login(Models.User user)
        {
            if (user.Email == null||user.Username == null)
            {
                return Problem("Username/email is needed");
            }
            if (user.Password == null)
            {
                return Problem("Password is needed");
            }


            return Forbid();

        }
    }
}
