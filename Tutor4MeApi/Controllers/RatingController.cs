using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutor4MeApi.Models;

namespace Tutor4MeApi.Data
{
    [Route("api/rating")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _service;

        public RatingController(IRatingService service)
        {
            _service = service;
        }

        [HttpPost("rating/add")]
        public IActionResult AddRating(Timeslot timeslot)
        {
            var result = _service.AddRating(timeslot);

            if(result == 0)
            {
                return NotFound($"Timeslot with TimeslotId: {timeslot.TimeslotId} was not found!!!");
            }

            return Ok($"Timeslot with TimeslotId: {timeslot.TimeslotId} was rated successfuly...");
        }

        [HttpGet("rating/getaverage")]
        public IActionResult GetTutorAverageRating(int tutorId)
        {
            var result = _service.GetTutorAverageRating(tutorId);

            if(result == null)
            {
                return NotFound($"Tutor with TutorId: {id} was not found!!!");
            }

            return Ok(result);
        }

        [HttpGet("rating/getaveragebymodule")]
        public IActionResult GetTutorAverageRatingByModule(int tutorId, int moduleId)
        {
            var result = _service.GetTutorAverageRatingByModule(id, int moduleId);

            if(result == null)
            {
                return NotFound($"Tutor with TutorId: {id} was not found!!!");
            }

            return Ok(result);
        }
    }
}