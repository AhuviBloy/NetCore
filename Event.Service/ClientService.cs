﻿using Event.Core.Models;
using Event.Core.Repositories;
using Event.Core.Services;
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

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public List<Client> GetAllClients()
        {
            return _clientRepository.GetAllClients();
        }

        public Client GetClientById(int id)
        {
            return _clientRepository.GetClientById(id);
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
