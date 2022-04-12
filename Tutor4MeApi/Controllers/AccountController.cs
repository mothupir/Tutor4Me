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
    }
}
