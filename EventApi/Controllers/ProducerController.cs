using GlaTicket.Class;
using GlaTicket.Data;
using GlaTicket.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private IDataContext dataContext;

        public ProducerController(IDataContext context)
        {
            dataContext = context;
        }

        // GET: api/<ProducerController>
        [HttpGet]
        public IEnumerable<Producer> Get()
        {
            return dataContext.producersList;
        }

        // GET api/<ProducerController>/5
        [HttpGet("{id}")]
        public Producer Get(int id)
        {
            return dataContext.producersList.FirstOrDefault(p => p.ProducerId == id && p.ProducerStatus == true);
        }

        // POST api/<ProducerController>
        [HttpPost]
        public void Post(int producerId, string producerName)
        {
            dataContext.producersList.Add(new Producer() { ProducerId = producerId, ProducerName = producerName, ProducerStatus = true, ProducerEventList = new List<int>() });
        }

        // DELETE api/<ProducerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dataContext.producersList.FirstOrDefault(p => p.ProducerId == id).ProducerStatus = false;
        }
    }
}
