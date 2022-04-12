using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutor4MeApi.Models;

namespace Tutor4MeApi.Data
{
    [Route("api/rating")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _service;

        public RatingController(IRatingService service)
        {
            _service = service;
        }

        
    }
}