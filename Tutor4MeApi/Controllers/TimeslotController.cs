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

        public TimeslotController (ITimeslotService timeslotService)
        {
            this.timeslotService=timeslotService;
        }

        [HttpPost("book")]
        public IActionResult addTimeslot (Timeslot timeslot)
        {
            var results = timeslotService.AddTimeslot(timeslot);
            if (results == 200)
            {
                return Ok($"Timeslot for {timeslot.Date} at {timeslot.StartTime} has been succesfully created");
            }
            else if(results == 400)
            {
                return BadRequest("Start tme cannot be after the end time");
            }
            else
            return Conflict("Timslot already exists");
            
        }
    }

}
