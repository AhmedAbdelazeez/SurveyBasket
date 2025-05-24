using SurveyBasket.Api.Mapping;
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
            var polls = _poolService.GetAll();
            return Ok(polls.MappToResponse());
        }

        [HttpGet(template: "{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var poll = _poolService.GetById(id);
            return poll is null ? NotFound() : Ok(poll.MappToResponse());
        }

        [HttpPost, Route("Add")]
        public IActionResult Add(CreatePollRequest request)
        {
            var newPoll = _poolService.Add(request.MappToPoll());

            return CreatedAtAction(nameof(Get), new { id = newPoll.Id }, newPoll);
        }

        [HttpPut(template: "{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] CreatePollRequest poll)
        {
            bool isupdate = _poolService.Update(id, poll.MappToPoll());
            if (!isupdate)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete(template: "{id}")]

        public IActionResult Delete([FromRoute] int id)
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
