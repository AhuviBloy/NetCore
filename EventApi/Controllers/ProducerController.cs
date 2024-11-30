using Event.Core.Interface;
using Event.Core.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Event.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private IDataContext _dataContext;

        public ProducerController(IDataContext context)
        {
            _dataContext = context;
        }

        // GET: api/<ProducerController>
        [HttpGet]
        public IEnumerable<Producer> Get()
        {
            return _dataContext.producersList;
        }

        // GET api/<ProducerController>/5
        [HttpGet("{id}")]
        public Producer Get(int id)
        {
            return _dataContext.producersList.FirstOrDefault(p => p.ProducerId == id && p.ProducerStatus == true);
        }

        // POST api/<ProducerController>
        [HttpPost]
        public void Post(int producerId, string producerName)
        {
            _dataContext.producersList.Add(new Producer() { ProducerId = producerId, ProducerName = producerName, ProducerStatus = true, ProducerEventList = new List<int>() });
        }

        // DELETE api/<ProducerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dataContext.producersList.FirstOrDefault(p => p.ProducerId == id).ProducerStatus = false;
        }
    }
}
