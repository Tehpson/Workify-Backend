namespace Workify_Backend.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http.Cors;

    [ApiController]
    [EnableCors("*", "*", "*")]
    public class UserTrainingDataController : ControllerBase
    {
        [HttpGet]
        [Route("api/user/{userId}/WorkoutData")]
        public IActionResult GetAll(ulong userId)
        {
            Models.User user;
            using(var db = new Database.WorkifyDatabase())
            {
                user = db.Users.FirstOrDefault(x => x.Id == userId);
            if (user == null) return NotFound("user Not Found");
            else
            {
                    if(user.Trainings == null)
                    {
                        return Ok(new List<string>());
                    }
                    var data = user.Trainings.ToList();
                    return Ok(data);
            }
            }
        }

        [HttpGet]
        [Route("api/user/{userId}/WorkoutData/{workoutid}")]
        public IActionResult GetAll(ulong userId, ulong workoutid)
        {
            Models.User user;
            using (var db = new Database.WorkifyDatabase())
            {
                user = db.Users.FirstOrDefault(x => x.Id == userId);
                if (user == null) return NotFound("user Not Found");
                else
                {
                    var data = user.Trainings.Where(x => x.Id == workoutid).ToList();
                   
                    return Ok(data);
                }
            }
        }

        [HttpPost]
        [Route("api/user/{userId}/WorkoutData")]
        public IActionResult Post(ulong userID, Models.UserTraining userTraining)
        {
            Models.User user;
            using (var db = new Database.WorkifyDatabase())
            {
                user = db.Users.FirstOrDefault(x => x.Id == userID);
                if(user == null)
                {
                    return NotFound("user Not found");
                }
            }

            if(userTraining.Title == null || userTraining.Title == "")
            {
                return Problem("Title need to be specified");
            }
            else if (userTraining.Title.Length > 25)
            {
                return Problem("title to long");
            }
            else if(userTraining.Time == null || userTraining.Time == "0")
            {
                return Problem("Time need to be specified");
            }
            else if(userTraining.Comment.Length > 200)
            {
                return Problem("comment to long");
            }
            else
            {
                var dateteim = System.DateTime.Now;

            }
            using (var db = new Database.WorkifyDatabase())
            {
                try
                {
                    user.Trainings.Add(new Models.UserTraining { Comment = userTraining.Comment, Date = System.DateTime.Now.ToString(), Layout = userTraining.Layout, Title = userTraining.Title, Time = userTraining.Time, ImgPath = "" });
                    db.SaveChanges();
                }
                catch { System.Console.WriteLine("ERROR"); }
            }
            return Ok("succsefull");
        }
    }
}