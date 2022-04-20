using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutor4MeApi.Data;
using Tutor4MeApi.Models;

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

        [HttpPost("addtutoredmodule/{tutorId}/{moduleId}")]
        public IActionResult AddTutoredModule(int tutorId, int modueId)
        {
            var result = _service.AddTutoredModule(tutorId, modueId);

            if(result == 0)
            {
                return Ok($"Module with ModuleId: {modueId} for Tutor with id: {tutorId} already exists!!!");
            }

            return Ok($"Module with ModuleId: {modueId} for Tutor with TutorId: {tutorId} was added successfully...");
        }

        [HttpDelete("removetutoredmodule/{tutorId}/{moduleId}")]
        public IActionResult RemoveTutoredModule(int tutorId, int modueId)
        {
            var result = _service.RemoveTutoredModule(tutorId, modueId);
            if( result == 0)
            {
                return NotFound($"Module with ModuleId: {modueId} for Tutor with id: {tutorId} was not found!!!");
            }

            return Ok($"Module with ModuleId: {modueId} for Tutor with TutorId: {tutorId} was removed successfully...");
        }

        [HttpPost("create")]
        public IActionResult CreateTutor(Tutor tutor)
        {
            var result = _service.CreateTutor(tutor);

            if (result == 0)
            {
                return Ok("tutor with the provided email already exists!!!");
            }
            else
            {
                return Ok("tutor added successfully...");
            }
        }

        [HttpGet("get/{id}")]
        public IActionResult GetTutor(int id)
        {
            var result = _service.GetTutor(id);

            if (result == null)
            {
                return NotFound($"Tutor with TutorId: {id} was not found!!!");
            }

            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult UpdateTutor(Tutor tutor)
        {
            var result = _service.UpdateTutor(tutor);

            if (result == 0)
            {
                return NotFound($"Tutor with TutorId: {tutor.TutordId} was not found!!!");
            }

            return Ok($"Tutor with TutorId: {tutor.TutordId} was updated successfuly...");
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteTutor(int id)
        {
            var result = _service.DeleteTutor(id);

            if (result == 0)
            {
                return NotFound($"Tutor with TutorId: {id} was not found!!!");
            }

            return Ok($"Tutor with TutorId: {id} was deleted successfuly...");
        }

        [HttpPost("rating/add/{tutorId}/{rating}")]
        public IActionResult AddRating(int tutorId, int rating)
        {
            var result = _service.AddRating(tutorId, rating);

            if (result == 0)
            {
                return NotFound($"Tutor with TutorId: {tutorId} was not found!!!");
            }

            return Ok($"Rating for tutor with TutorId: {tutorId} was added successfully...");
        }

        [HttpGet("rating/getaverage/{tutorId}")]
        public IActionResult GetTutorAverageRating(int tutorId)
        {
            var result = _service.GetTutorAverageRating(tutorId);

            if (result == null)
            {
                return NotFound($"Tutor with TutorId: {tutorId} was not found!!!");
            }

            return Ok(result);
        }

        [HttpGet("get/tutors/{moduleId}")]
        public IActionResult getAllTutorsByModule(int moduleId)
        {
            var result = _service.getAllTutorsByModule(moduleId);
            if (result.Count == 0)
            {
                return NotFound($"Tutors for the module with ModuleId: {moduleId} were not found!!!");
            }
            return Ok(result);

        }
        [HttpGet("get/tutors/")]
        public IActionResult GetAllTutors()
        {
            var result = _service.getAllTutors();
            if (result.Count == 0)
            {
                return NotFound($"No tutor was found!!!");
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
