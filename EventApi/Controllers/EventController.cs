
using Event.Core.Interface;
using Event.Core.Models;
using Event.Core.Services;
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
        public List<SingleEvent> Get()
        {
            return _eventService.GetAllEvents();
        }

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public SingleEvent Get(int id)
        {
           return _eventService.GetEventById(id);
        }

        // POST api/<EventController>
        [HttpPost]
        public void Post([FromBody] SingleEvent eventt)
        {
            _eventService.PostEvent(eventt);
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] SingleEvent eventt)
        {
            _eventService.PutEvent(eventt);
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _eventService.DeleteEvent(id);
        }
    }
}
 