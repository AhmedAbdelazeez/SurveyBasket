using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyBasket.Api.Models;
using SurveyBasket.Api.Services;
using System.Reflection.Metadata.Ecma335;

namespace SurveyBasket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollsController : ControllerBase
    {
       private readonly IPollServices _services;

        public PollsController(IPollServices services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult Getall()
        {

            return Ok(_services.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var poll = _services.GetById(id);
            return poll is not null ? Ok(poll) : NotFound();    
        }

        [HttpPost(template:"Addnewpoll")]

        public IActionResult AddNewPoll(Poll newpoll)
        {
            _services.Add(newpoll);

            return Created(); 
        }

        [HttpPut(template:"{id}")]

        public IActionResult update(int id,Poll newpoll)
        {
            var isupdated = _services.Update(id, newpoll);

            if (!isupdated)
                return NotFound();

            return NoContent();
           
        }

        [HttpDelete(template: "{id}")]

        public IActionResult Delete(int id)
        {
            var isdeleted = _services.Delete(id);

            if (!isdeleted)
                return NotFound();

            return NoContent();

        }
    }
}
