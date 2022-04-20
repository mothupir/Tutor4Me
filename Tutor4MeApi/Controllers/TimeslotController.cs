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
        public IActionResult CreateTimeslot(Timeslot timeslot)
        {
            var results = timeslotService.CreateTimeslot(timeslot);
            if (results == 200)
            {
                return Ok($"Timeslot for {timeslot.Date} at {timeslot.StartTime} has been succesfully created");
            }
            else if (results == 400)
            {
                return BadRequest("Invalid values");
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
            else if (results ==400)
            {
                return BadRequest("Please provide valid values");
            }

            return StatusCode(500, "Timeslot could not be booked");
        }
        [HttpPut("cancel/{timeslotID}")]
        public IActionResult CancelBooking (int timeslotID)
        {
            var results = timeslotService.CancelBooking(timeslotID);

            if (results ==200)
            {
                return Ok("Bokking successfuly cancelled");
            }
            else if (results==404)
            {
                return NotFound("Booking does not exist");
            }
            return StatusCode(500, "Booking could not be  cancelled");

        }

        [HttpGet("get/timeslots{tutorID}")]
        public IActionResult getTimeslots (int tutorID)
        {
            var results = timeslotService.getTimeslots(tutorID);
            return Ok(results);

        }
        [HttpPut("deleteTimeslot{timeslotID}")]
        public  IActionResult deleteTimeslot (int timeslotID)
        {
            var results = timeslotService.deleteTimeslot(timeslotID);
            if (results == 200)
            {
                return Ok("Timeslot successfully deleted");
            }
            if (results ==404)
            {
                return NotFound("Timeslot does not exist");
            }
            return StatusCode(500, "Timeslot could not be deleted");

        }

        [HttpGet("get/bookings{tutorID}")]
        public IActionResult getBookedTimeslotsTutor(int tutorID)
        {
            var results = timeslotService.GetBookedTimeslotsTutor(tutorID);
            return Ok(results);
        }
        [HttpGet("get/booked{studentID}")]
        public IActionResult  getBookingsStudent(int studentID)
        {
            var results = timeslotService.GetBookedTimeslotsTutor(studentID);
            return Ok(results);
        }

        [HttpGet("get/bookings/available/{tutorID}")]
        public IActionResult GetTutorAvailableTimeslots(int tutorID)
        {
            var availableTimeslots = timeslotService.GetTutorAvailableTimeslots(tutorID);
            if (availableTimeslots.Count==0)
                return NotFound("No available timeslots for this tutor");
            return Ok(availableTimeslots);
        }
    }
}
