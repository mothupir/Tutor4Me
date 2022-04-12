using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutor4MeApi.Models;

namespace Tutor4MeApi.Data
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        // Tutor
        [HttpPost("tutor/create")]
        public IActionResult CreateTutor(Tutor tutor)
        {
            var result = _service.CreateTutor(tutor);

            if(result == 0)
            {
                return Ok("tutor with the provided email already exists!!!");
            } 
            else
            {
                return Ok("tutor added successfully...");
            }
        }

        public IActionResult GetTutor(int id)
        {
            var result = _service.GetTutor(id);

            if(result == null)
            {
                return NotFound($"Tutor with TutorId: {id} was not found!!!");
            }

            return Ok(result);
        }

        public IActionResult UpdateTutor(Tutor tutor)
        {
            var result = _service.UpdateTutor(tutor);

            if(result == 0)
            {
                return NotFound($"Tutor with TutorId: {tutor.TutordId} was not found!!!");
            }

            return Ok($"Tutor with TutorId: {tutor.TutordId} was updated successfuly...");
        }

        public IActionResult DeleteTutor(int id)
        {
            var result = _service.DeleteTutor(id);

            if (result == 0)
            {
                return NotFound($"Tutor with TutorId: {id} was not found!!!");
            }

            return Ok($"Tutor with TutorId: {id} was deleted successfuly...");
        }


        // Student
        [HttpPost("student/create")]
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

        public IActionResult GetStudent(int id)
        {
            var result = _service.GetStudent(id);

            if (result == null)
            {
                return NotFound($"Student with StudentId: {id} was not found!!!");
            }

            return Ok(result);
        }

        public IActionResult UpdateStudent(Student student)
        {
            var result = _service.UpdateStudent(student);

            if (result == 0)
            {
                return NotFound($"Student with StudentId: {student.StudentId} was not found!!!");
            }

            return Ok($"Studnt with StudentId: {student.StudentId} was updated successfuly...");
        }

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
