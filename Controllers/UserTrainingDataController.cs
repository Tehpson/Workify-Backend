namespace Workify_Backend.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Route("api/user/{Id}/WorkoutData/")]
    [ApiController]
    public class UserTrainingDataController : ControllerBase
    {
        [HttpGet]
        [Route("api/user/{userId}/WorkoutData/")]
        public IActionResult GetAll(string userId)
        {
            return NotFound();
        }

        [HttpGet]
        [Route("api/user/{userId}/WorkoutData/{workoutid}")]
        public IActionResult GetAll(string userId, int workoutid)
        {
            return NotFound();
        }
    }
}