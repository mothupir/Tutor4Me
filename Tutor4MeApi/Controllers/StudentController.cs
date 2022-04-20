using Microsoft.AspNetCore.Mvc;
using Tutor4MeApi.Data;
using Tutor4MeApi.Models;

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

        [HttpPost("create")]
        public IActionResult CreateStudent(Student student)
        {
            var result = _service.CreateStudent(student);

            if (result == 0)
            {
                return Ok("student with the provided email already exists!!!");
            }
            else
            {
                return Ok("student added successfully...");
            }
        }

        [HttpGet("get/{id}")]
        public IActionResult GetStudent(int id)
        {
            var result = _service.GetStudent(id);

            if (result == null)
            {
                return NotFound($"Student with StudentId: {id} was not found!!!");
            }

            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult UpdateStudent(Student student)
        {
            var result = _service.UpdateStudent(student);

            if (result == 0)
            {
                return NotFound($"Student with StudentId: {student.StudentId} was not found!!!");
            }

            return Ok($"Studnt with StudentId: {student.StudentId} was updated successfuly...");
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var result = _service.DeleteStudent(id);

            if (result == 0)
            {
                return NotFound($"Student with StudentId: {id} was not found!!!");
            }

            return Ok($"Student with StudentId: {id} was deleted successfuly...");
        }
    }

}
