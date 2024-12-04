using Event.Core.Models;
using Event.Core.Repositories;
using Event.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Service
{
    public class TicketService:ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IClientService _clientService;

        public TicketService(ITicketRepository ticketRepository,IClientService clientService)
        {
            _ticketRepository = ticketRepository;
            _clientService = clientService;
        }
        public void BuyTicket(Ticket ticket) //קנית כרטיס
        {
            _clientService.AddTicketToClient(ticket);
        }
    }
}
