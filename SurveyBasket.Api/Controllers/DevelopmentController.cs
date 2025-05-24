using Microsoft.AspNetCore.Mvc;
using SurveyBasket.Api.Services;

namespace SurveyBasket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopmentController : ControllerBase
    {
        private readonly IOS _service;

        public DevelopmentController(IOS service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult get()
        {
            var message = _service.RunApp();
            return Ok(message);
        }
    }
}
