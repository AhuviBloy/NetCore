
using Event.Core.Interface;
using Event.Core.Models;
using Event.Core.Services;
using GlaTicket.Core.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Event.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        // POST api/<TicketController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] TicketPostDTO ticket)
        {
            _ticketService.BuyTicket(ticket);
            return Ok(true);
        }

    }
}
