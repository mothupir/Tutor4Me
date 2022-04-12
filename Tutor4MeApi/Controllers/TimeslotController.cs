using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutor4MeApi.Models;


//why this namespace?
namespace Tutor4MeApi.Data
{
    [Route("api/timeslot")]
    [ApiController]
    public class TimeslotController : ControllerBase
    {
        private readonly ITimeslotService timeslotService;

        public TimeslotController(ITimeslotService timeslotService)
        {
            this.timeslotService = timeslotService;
        }

        [HttpPost("create")]
        public IActionResult AddTimeslot(Timeslot timeslot)
        {
            var results = timeslotService.CreateTimeslot(timeslot);
            if (results == 200)
            {
                return Ok($"Timeslot for {timeslot.Date} at {timeslot.StartTime} has been succesfully created");
            }
            else if (results == 400)
            {
                return BadRequest("Start time cannot be after the end time");
            }
            else
                return Conflict("Timslot already exists");

        }

        [HttpPut("book/{studentID}/{moduleID}")]
        public IActionResult BookTimeslot(int studentID, int moduleID, [FromBody] int timeslotID)
        {
            var results = timeslotService.BookTimeslot(studentID, moduleID, timeslotID);
            if (results == 200)
            {
                return Ok($"A booking with a tutor has been successfull");
            }
            else if (results == 404)
            {
                return NotFound("Cannot  book a timeslot that does not exist");
            }
            else if (results == 409)
            {
                return Conflict("This timeslot has already been booked");
            }

            return StatusCode(500, "Timeslot could not be booked");
        }
    }
}
