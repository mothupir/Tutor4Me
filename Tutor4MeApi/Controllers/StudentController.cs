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
        

        [HttpPost("create")]
        public IActionResult CreateStudent(Student student)
        {
            var result = _service.CreateStudent(student);

            if (result == null)
            {
                return Ok("student with the provided email already exists!!!");
            }
            else
            {
                return Ok(result);
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
