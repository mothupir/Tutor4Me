using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutor4MeApi.Data;

namespace Tutor4MeApi.Controllers
{
    [Route("api/tutor")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        private readonly ITutorService _service;

        public TutorController(ITutorService service)
        {
            _service = service;
        }

        //[HttpPost("")]
        public IActionResult AddTutoredModule(int tutorId, int modueId)
        {
            var result = _service.AddTutoredModule(tutorId, modueId);

            if(result == 0)
            {
                return Ok($"Module with ModuleId: {modueId} for Tutor with id: {tutorId} already exists!!!");
            }

            return Ok($"Module with ModuleId: {modueId} for Tutor with TutorId: {tutorId} was added successfully...");
        }

        public IActionResult RemoveTutoredModule(int tutorId, int modueId)
        {
            var result = _service.RemoveTutoredModule(tutorId, modueId);
            if( result == 0)
            {
                return NotFound($"Module with ModuleId: {modueId} for Tutor with id: {tutorId} was not found!!!");
            }

            return Ok($"Module with ModuleId: {modueId} for Tutor with TutorId: {tutorId} was removed successfully...");
        }
    }
}
