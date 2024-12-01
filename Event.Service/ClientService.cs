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
        public void PostClient(int id, string name)//הוספת לקוח חדש
        {
            _clientRepository.PostClient(id,name);
        }
        public void PutClient(Ticket ticket) // הכנסת כרטיס ללקוח
        {
            _clientRepository.PutClient(ticket);
        }

        //public void DeleteTicket(Ticket ticket); //מחיקת כרטיס ללקוח  
    }
}
