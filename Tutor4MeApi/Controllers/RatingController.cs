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

        [HttpPost("rating/add/{tutorId}/{rating}")]
        public IActionResult AddRating(int tutorId, int rating)
        {
            var result = _service.AddRating(tutorId, rating);

            if(result == 0)
            {
                return NotFound($"Tutor with TutorId: {tutorId} was not found!!!");
            }

            return Ok($"Rating for tutor with TutorId: {tutorId} was added successfully...");
        }

        [HttpGet("rating/getaverage/{tutorId}")]
        public IActionResult GetTutorAverageRating(int tutorId)
        {
            var result = _service.GetTutorAverageRating(tutorId);

            if(result == null)
            {
                return NotFound($"Tutor with TutorId: {tutorId} was not found!!!");
            }

            return Ok(result);
        }

        [HttpGet("rating/getaveragebymodule/{tutorId}/{moduleId}")]
        public IActionResult GetTutorAverageRatingByModule(int tutorId, int moduleId)
        {
            var result = _service.GetTutorAverageRatingByModule(tutorId, moduleId);

            if(result == null)
            {
                return NotFound($"Tutor with TutorId: {tutorId} was not found!!!");
            }

            return Ok(result);
        }
    }
}