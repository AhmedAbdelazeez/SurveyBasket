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
            var response = polls.Adapt<IEnumerable<Poll>>();
            return Ok(response);
        }

        [HttpGet(template: "{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var poll = _poolService.GetById(id);

            //  var response = poll.Adapt<PollResponse>(config);
            return poll is null ? NotFound() : Ok(poll);
        }

        [HttpPost, Route("Add")]
        public IActionResult Add([FromBody] CreatePollRequest request)
        {
            var newPoll = _poolService.Add(request.Adapt<Poll>());
            return CreatedAtAction(nameof(Get), new { id = newPoll.Id }, newPoll);
        }

        [HttpPut(template: "{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] CreatePollRequest request)
        {
            bool isupdate = _poolService.Update(id, request.Adapt<Poll>());
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
