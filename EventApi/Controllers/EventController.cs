
using Event.Core.Interface;
using Event.Core.Models;
using Event.Core.Services;
using GlaTicket.Core.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService) 
        {
            _eventService = eventService;
        }

        // GET: api/<EventController>
        [HttpGet]
        public ActionResult<List<EventGetDTO>> Get()
        {
            var tmp=_eventService.GetAllEvents();
            return Ok(tmp);
        }

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public ActionResult<EventGetDTO> Get(int id)
        {
            var tmp=_eventService.GetEventById(id);
            if (tmp == null)
                return NotFound("There is no an event with that id");
            return Ok(tmp);
        }

        // POST api/<EventController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] EventPostDTO eventt)
        {
            _eventService.AddNewEvent(eventt);
            return Ok(true);
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] SingleEvent eventt)
        {
            _eventService.UpdateEventDetails(eventt);
            return Ok(true);
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            _eventService.DeleteInactiveEvent(id);
            return Ok(true);
        }
    }
}
 