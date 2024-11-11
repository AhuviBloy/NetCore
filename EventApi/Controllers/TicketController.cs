using EventCore.Class;
using EventCore.Data;
using EventCore.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private IDataContext dataContext;

        public TicketController(IDataContext context)
        {
            dataContext = context;
        }

        // POST api/<TicketController>
        [HttpPost]
        public void Post([FromBody] Ticket ticket)
        {
            if (dataContext.eventList.Any(e => e.EventCode == ticket.EventCode && e.EventStatus == true))
            {
                if (dataContext.clientList.Any(c => c.ClientId == ticket.ClientId))
                {
                    dataContext.clientList.FirstOrDefault(c => c.ClientId == ticket.ClientId).ClientTicketList.Add(ticket.EventCode);
                }
                else
                {
                    dataContext.clientList.Add(new Client() { ClientId = ticket.ClientId, ClientName = ticket.ClientName, ClientStatus = true, ClientTicketList = new List<int>() { ticket.EventCode } });
                }
            }
        }

    }
}
