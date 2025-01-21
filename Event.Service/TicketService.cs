using AutoMapper;
using Event.Core.Models;
using Event.Core.Repositories;
using Event.Core.Services;
using GlaTicket.Core.DTO;
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
        private readonly IMapper _mapper;


        public TicketService(ITicketRepository ticketRepository,IClientService clientService,IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _clientService = clientService;
            _mapper = mapper;
        }
        public void BuyTicket(TicketPostDTO ticket) //קנית כרטיס
        {
            _ticketRepository.AddTicketToDb(_mapper.Map<Ticket>( (ticket)));
            _clientService.AddTicketToClient(_mapper.Map<Ticket>((ticket)));
        }
    }
}
