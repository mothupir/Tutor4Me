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

        [HttpPost("delete")]
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

        [HttpGet("getAll")]
        public List<Module> GetAllModules()
        {
            return  _service.GetAllModules();
        }

    }
}
