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
using System.Xml.Linq;

namespace Event.Service
{
    public class ClientService:IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;


        public ClientService(IClientRepository clientRepository,IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public List<ClientGetDTO> GetAllClients()
        {
            var list = _clientRepository.GetAllClients();
            var listDto = new List<ClientGetDTO>();
            foreach (var client in list)
            {
                listDto.Add(_mapper.Map<ClientGetDTO>(client));
            }
            return listDto;
        }

        public ClientGetDTO GetClientById(int id)
        {
            return _mapper.Map<ClientGetDTO>(_clientRepository.GetClientById(id));
        }

        public void AddNewClient(int id, string name)
        {
            Client client = new Client
            {
                ClientId = id,
                ClientName = name,
                ClientTicketList = new List<Ticket>(),
                ClientStatus = true
            };

            _clientRepository.AddNewClient(client);
        }

        public void AddTicketToClient(Ticket ticket) // הכנסת כרטיס ללקוח
        {
            Client temp = _clientRepository.GetClientById(ticket.ClientId);

            if (temp == null)
            {
                AddNewClient(ticket.ClientId, ticket.ClientName);
            }

            _clientRepository.AddTicketToClient(ticket);
        }

        //public void DeleteTicketToClient(Ticket ticket); //מחיקת כרטיס ללקוח  
    }
}
