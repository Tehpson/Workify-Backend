namespace Workify_Backend.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    [ApiController]
    public class UserTrainingDataController : ControllerBase
    {
        [HttpGet]
        [Route("api/user/{userId}/workoutdata")]
        public IActionResult GetAll(ulong userId)
        {
            Models.User user;
            using (var db = new Database.WorkifyDatabase())
            {
                user = db.Users.Include("Trainings").FirstOrDefault(x => x.Id == userId);
                if (user == null) return NotFound("user Not Found");
                else
                {
                    var data = user.Trainings;
                    return Ok(data);
                }
            }
        }

        [HttpGet]
        [Route("api/user/{userId}/workoutdata/{workoutid}")]
        public IActionResult GetAll(ulong userId, ulong workoutid)
        {
            Models.User user;
            using (var db = new Database.WorkifyDatabase())
            {
                user = db.Users.FirstOrDefault(x => x.Id == userId);
                if (user == null) return NotFound("user Not Found");
                else
                {
                    var data = user.Trainings.Where(x => x.Id == workoutid);
                    return Ok(data);
                }
            }
        }

        [HttpPost]
        [Route("api/user/{userId}/workoutdata")]
        public IActionResult Post(ulong userID, Models.UserTraining userTraining)
        {
            Models.User user;
            using (var db = new Database.WorkifyDatabase())
            {
                user = db.Users.Include("Trainings").FirstOrDefault(x => x.Id == userID);
                if (user == null)
                {
                    return NotFound("user Not found");
                }

                if (userTraining.Title == null)
                {
                    return Problem("Title need to be specified");
                }
                else if (userTraining.Title.Length > 25)
                {
                    return Problem("title to long");
                }
                else if (userTraining.Time == null)
                {
                    return Problem("Time need to be specified");
                }
                else if (userTraining.Comment.Length > 250)
                {
                    return Problem("comment to long");
                }
                else
                {
                    var dateteim = System.DateTime.Now;
                }
                user.Trainings.Add(new Models.UserTraining { Comment = userTraining.Comment, Date = System.DateTime.Now.ToString(), Layout = 0, Title = userTraining.Title, Time = userTraining.Time, ImgPath = "" });
                db.SaveChanges();
            }
            return Ok("succsefull");
        }
    }
}