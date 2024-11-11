using EventCore.Class;
using GlaTicket.Data;
using GlaTicket.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private IDataContext dataContext;

        public EventController(IDataContext context)
        {
            dataContext = context;
        }

        // GET: api/<EventController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {

            return dataContext.eventList;
        }

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public Event Get(int id)
        {
            return dataContext.eventList.FirstOrDefault(e => e.EventCode == id && e.EventStatus == true);
        }

        // POST api/<EventController>
        [HttpPost]
        public void Post([FromBody] Event eventt)
        {
            dataContext.eventList.Add(eventt);
            if (dataContext.producersList.Any(p => p.ProducerId == eventt.EventProducerId))
            {
                dataContext.producersList.FirstOrDefault(p => p.ProducerId == eventt.EventProducerId).ProducerEventList.Add(eventt.EventCode);
            }

        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event eventt)
        {
            Event temp = dataContext.eventList.FirstOrDefault(e => e.EventCode == id);
            temp.EventDate = eventt.EventDate;
            temp.EventPrice = eventt.EventPrice;
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dataContext.eventList.FirstOrDefault(e => e.EventCode == id).EventStatus = false;
        }
    }
}
