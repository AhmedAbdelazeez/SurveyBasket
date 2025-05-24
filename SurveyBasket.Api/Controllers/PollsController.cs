using SurveyBasket.Api.Services;

namespace SurveyBasket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollsController : ControllerBase
    {
        private readonly IPollService _poolService;

        public PollsController(IPollService poolService)
        {
            _poolService = poolService;
        }

        [HttpGet(template: "GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_poolService.GetAll());
        }

        [HttpGet(template: "{id}")]
        public IActionResult Get(int id)
        {


            return Ok(_poolService.GetById(id));
        }

        [HttpPost]
        public IActionResult Add(Poll request)
        {
            var newPoll = _poolService.Add(request);

            return CreatedAtAction(nameof(Get), new { id = newPoll.Id }, newPoll);
        }

        [HttpPut(template: "{id}")]
        public IActionResult Update(int id, Poll poll)
        {
            bool isupdate = _poolService.Update(id, poll);
            if (!isupdate)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete(template: "{id}")]

        public IActionResult Delete(int id)
        {
            bool isDeleted = _poolService.Delete(id);

            if (!isDeleted)
            {
                return NotFound();
            }

            return Ok();

        }

    }
}
