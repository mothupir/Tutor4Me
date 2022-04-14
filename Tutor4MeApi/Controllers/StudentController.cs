using Microsoft.AspNetCore.Mvc;
using Tutor4MeApi.Data;

namespace Tutor4MeApi.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {


            _service = service;
        }
        [HttpGet("tutor/get/{moduleId}")]
        public IActionResult getAllTutorsByModule(int moduleId)
        {
            var result = _service.getAllTutorsByModule(moduleId);
            return Ok(result);

        }
        [HttpGet("tutor/get/")]
        public IActionResult GetAllTutors()
        {
            var result = _service.getAllTutors();

            return Ok(result);
        }

        [HttpGet("tutor/get/Modules/{tutorId}")]

        public IActionResult GetOfferedModulesByTutor(int tutorId)
        {
            var result = _service.getOfferedModulesByTutor(tutorId);
            return Ok(result);
        }

        [HttpGet("tutor/get/Information/{tutorId}")]

        public IActionResult GetTutorInformation(int tutorId)
        {
            var result = _service.getTutorInformation(tutorId);
            return Ok(result);
        }
    }

}
