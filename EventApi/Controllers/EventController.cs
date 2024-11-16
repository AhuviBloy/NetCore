using EventCore.Class;
using EventCore.Data;
using EventCore.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private IDataContext _dataContext;

        public EventController(IDataContext context)
        {
            _dataContext = context;
        }

        // GET: api/<EventController>
        [HttpGet]
        public ActionResult<IEnumerable<Event>> Get()
        {
            return Ok(_dataContext.eventList);
        }

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public ActionResult<Event> Get(int id)
        {
            var eventItem = _dataContext.eventList.FirstOrDefault(e => e.EventCode == id && e.EventStatus == true);
            if (eventItem == null)
            {
                return NotFound($"Event with ID {id} not found or inactive.");
            }
            return Ok(eventItem);
        }

        // POST api/<EventController>
        [HttpPost]
        public void Post([FromBody] Event eventt)
        {
            _dataContext.eventList.Add(eventt);
            if (_dataContext.producersList.Any(p => p.ProducerId == eventt.EventProducerId))
            {
                _dataContext.producersList.FirstOrDefault(p => p.ProducerId == eventt.EventProducerId).ProducerEventList.Add(eventt.EventCode);
            }

        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event eventt)
        {
            Event temp = _dataContext.eventList.FirstOrDefault(e => e.EventCode == id);
            temp.EventDate = eventt.EventDate;
            temp.EventPrice = eventt.EventPrice;
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dataContext.eventList.FirstOrDefault(e => e.EventCode == id).EventStatus = false;
        }
    }
}
 