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

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public void PostTicket(Ticket ticket) //קנית כרטיס
        {
            _ticketRepository.PostTicket(ticket);
        }
    }
}
