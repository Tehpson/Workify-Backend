namespace Workify_Backend.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    [ApiController]
    public class UserTrainingDataController : ControllerBase
    {
        [HttpGet]
        [Route("api/user/{userId}/WorkoutData")]
        public IActionResult GetAll(string userId)
        {
            return Ok("yeey");
            return NotFound();
        }

        [HttpGet]
        [Route("api/user/{userId}/WorkoutData/{workoutid}")]
        public IActionResult GetAll(string userId, int workoutid)
        {
            return NotFound();
        }

        [HttpPost]
        [Route("api/user/{userId}/WorkoutData")]
        public IActionResult Post(ulong userID, Models.UserTraining userTraining)
        {
            using (var db = new Database.WorkifyDatabase())
            {
                var user = db.Users.FirstOrDefault(x => x.Id == userID);
                if(user == null)
                {
                    return NotFound("user Not found");
                }
            }

            if(userTraining.Title == null)
            {
                return Problem("Title need to be specified");
            }
            else if (userTraining.Title.Length > 25)
            {
                return Problem("title to long");
            }
            else if(userTraining.Time == null)
            {
                return Problem("Time need to be specified");
            }
            else if(userTraining.Comment.Length > 250)
            {
                return Problem("comment to long");
            }
            else
            {
                var dateteim = System.DateTime.Now;

            }
            return NotFound();
        }
    }
}