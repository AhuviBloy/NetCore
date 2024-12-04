using Event.Core.Interface;
using Event.Core.Models;
using Event.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Event.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IProducerService _producerService;

        public ProducerController(IProducerService producerService)
        {
            _producerService = producerService;
        }

        // GET: api/<ProducerController>
        [HttpGet]
        public List<Producer> Get()
        {
            return _producerService.GetAllProducers();
        }

        // GET api/<ProducerController>/5
        [HttpGet("{id}")]
        public Producer Get(int id)
        {
            return _producerService.GetProducerById(id);
        }

        // POST api/<ProducerController>
        [HttpPost]
        public ActionResult<bool> Post(int producerId, string producerName)
        {
            _producerService.PostProducer(producerId, producerName);
            return Ok(true);
        }

        //DELETE api/<ProducerController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return Ok(true);
        }
    }
}
