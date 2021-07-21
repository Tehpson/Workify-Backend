namespace Workify_Backend.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    [ApiController]
    public class UserController : ControllerBase
    {
        [Route("api/[controller]/{userID}")]
        [HttpGet]
        public IActionResult Get(string userID)
        {
            using (var db = new Database.WorkifyDatabase())
            {
                if (userID == null || userID == "undefined")
                {
                    return Problem("userId is not found");
                }
                var user = db.Users.FirstOrDefault(x => x.Id == ulong.Parse(userID));
                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return NotFound("user not found");
                }
            }
        }

        [Route("api/user/createuser")]
        [HttpPost]
        public IActionResult CreateUser(Models.User user)
        {
            if (user.Email == null || user.Email == "")
            {
                return Problem("Email is needed");
            }
            else if (user.Username == null || user.Username == "")
            {
                return Problem("Username is needed");
            }
            else if (user.Password == null || user.Password == "" )
            {
                return Problem("Password is needed");
            }
            else
            {
                using (var dataList = new Database.WorkifyDatabase())
                {
                    if (dataList.Users.Count(x => x.Username == user.Username) != 0)
                    {
                        return Forbid("Username is taken");
                    }
                    else if (dataList.Users.Count(x => x.Email == user.Email) != 0)
                    {
                        return Forbid("Email is taken");
                    }
                    else if (user.Password.Length < 8)
                    {
                        return Forbid("Password is too short");
                    }
                    else
                    {
                        var hashedPassword = Functions.Hashing.HashPassword(user.Password);
                        dataList.Users.Add(new Models.User { Email = user.Email, Password = hashedPassword, Username = user.Username, PublicProfile = true });
                        dataList.SaveChanges();
                        return Ok(dataList.Users.FirstOrDefault(x=>x.Email == user.Email).Id);
                    }
                }
            }
        }

        [HttpPost]
        [Route("api/user/login")]
        public IActionResult Login(Models.LoginModle user)
        {
            if (user.Email == null)
            {
                return Problem("Username/email is needed");
            }
            if (user.Password == null)
            {
                return Problem("Password is needed");
            }
            using (var db = new Database.WorkifyDatabase())
            {
                var userFromDB = db.Users.FirstOrDefault(x => x.Email == user.Email || x.Username == user.Email);
                if (userFromDB == null)
                {
                    return NotFound("username/email not found");
                }
                else if (!Functions.Hashing.VerifyPassword(user.Password, userFromDB.Password))
                {
                    return Forbid("password does not match");
                }
                else
                {
                    return Ok(userFromDB.Id);
                }
            }
        }
    }
}