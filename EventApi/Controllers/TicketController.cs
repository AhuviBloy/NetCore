
using Event.Core.Interface;
using Event.Core.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Event.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private IDataContext _dataContext;

        public TicketController(IDataContext context)
        {
            _dataContext = context;
        }

        // POST api/<TicketController>
        [HttpPost]
        public void Post([FromBody] Ticket ticket)
        {
            if (_dataContext.eventList.Any(e => e.EventCode == ticket.EventCode && e.EventStatus == true))
            {
                if (_dataContext.clientList.Any(c => c.ClientId == ticket.ClientId))
                {
                    _dataContext.clientList.FirstOrDefault(c => c.ClientId == ticket.ClientId).ClientTicketList.Add(ticket.EventCode);
                }
                else
                {
                    _dataContext.clientList.Add(new Client() { ClientId = ticket.ClientId, ClientName = ticket.ClientName, ClientStatus = true, ClientTicketList = new List<int>() { ticket.EventCode } });
                }
            }
        }

    }
}
