namespace Workify_Backend.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IActionResult Get(string username,string password)
        {
            var list = new List<string> { username, password };
            return Ok(list);
            //return Problem("username and password does not match");
        }
    }
}
