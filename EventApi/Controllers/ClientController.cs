
using Event.Core.Interface;
using Event.Core.Models;
using Event.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Event.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // GET: api/Client
        [HttpGet]
        public ActionResult<List<Client>> Get()
        {
           return Ok(_clientService.GetAllClients());
        }

        // GET api/Client/{id}
        [HttpGet("{id}")]
        public ActionResult<Client> Get(int id)
        {
            var tmp = _clientService.GetClientById(id);
            if(tmp == null) 
                return NotFound("The user isn't exsist");
            return Ok(tmp);
        }


        //// DELETE api/<ClientController>/5
        //[HttpDelete("{id}")]
        //public ActionResult<bool> Delete(int id, Ticket ticket)
        //{
        //    return Ok(true);
        //}
    }
}
