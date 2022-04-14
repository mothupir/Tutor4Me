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
        [HttpGet("get/tutors/{moduleId}")]
        public IActionResult getAllTutorsByModule(int moduleId)
        {
            var result = _service.getAllTutorsByModule(moduleId);
            if (result.Count==0)
            {
                return NotFound($"Tutors for the module with ModuleId: {moduleId} were not found!!!");
            }
            return Ok(result);

        }
        [HttpGet("get/tutors/")]
        public IActionResult GetAllTutors()
        {
            var result = _service.getAllTutors();
            if (result.Count==0)
            {
                return NotFound($"No tutor was found!!!");
            }
            return Ok(result);
        }

        [HttpGet("get/modules/{tutorId}")]

        public IActionResult GetOfferedModulesByTutor(int tutorId)
        {
            var result = _service.getOfferedModulesByTutor(tutorId);
            if (result.Count == 0)
            {
                return NotFound($"No module offered by tutor with tutorId:{tutorId} was found!!!");
            }
            return Ok(result);
        }

        [HttpGet("get/tutorInformation/{tutorId}")]

        public IActionResult GetTutorInformation(int tutorId)
        {
            var result = _service.getTutorInformation(tutorId);
            if (result == null)
            {
                return NotFound($"Tutor with TutorId: {tutorId} was not found!!!");
            }
            return Ok(result);
        }
    }

}
