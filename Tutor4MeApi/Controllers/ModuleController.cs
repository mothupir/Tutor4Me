using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutor4MeApi.Models;

namespace Tutor4MeApi.Data
{
    [Route("api/module")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService _service;

        public ModuleController(IModuleService service)
        {
            _service = service;
        }


        [HttpGet("get/modules/{tutorId}")]
        public IActionResult GetOfferedModulesByTutor(int tutorId)
        {
            var result = _service.GetOfferedModulesByTutor(tutorId);
            if (result.Count == 0)
            {
                return NotFound($"No module offered by tutor with tutorId:{tutorId} was found!!!");
            }
            return Ok(result);
        }

        [HttpPost("create")]
        public IActionResult CreateModule(Module module)
        {
            var result = _service.CreateModule(module);

            if (result == 0)
            {
                return Ok("error: module could not be created");
            }
            else
            {
                return Ok("module created successfully...");
            }
        }

        [HttpDelete("delete/{moduleId}")]
        public IActionResult DeleteModule(int moduleId)
        {
            var result = _service.DeleteModule(moduleId);

            if (result == 0)
            {
                return Ok("error: module could not be deleted");
            }
            else
            {
                return Ok("module deleted successfully...");
            }
        }

        [HttpGet("get/{moduleId}")]
        public Module GetModule(int moduleId)
        {
            return _service.GetModule(moduleId);

    
        }

        [HttpGet("getAll")]
        public List<Module> GetAllModules()
        {
            return  _service.GetAllModules();
        }

        [HttpGet("getModuleByNameSubstring/{searchTerm}")]
        public List<Module> GetModuleByNameSubstring(String searchTerm)
        {
            return _service.GetModuleByNameSubstring(searchTerm);
        }

        [HttpGet("getModuleByKeywordDesc/{searchTerm}")]
        public List<Module> GetModuleByKeywordDesc(String searchTerm)
        {
            return _service.GetModuleByKeywordDesc(searchTerm);
        }


    }
}
