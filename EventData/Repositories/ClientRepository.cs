using Event.Core.Interface;
using Event.Core.Models;
using Event.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Data.Repositories
{
    public class ClientRepository:IClientRepository
    {
        private readonly IDataContext _dataContext;

        public ClientRepository(IDataContext context)
        {
            _dataContext = context;
        }

        public List<Client> GetAllClients()
        {
            return _dataContext.clientList;
        }

        public Client GetClientById(int id)
        {
           return _dataContext.clientList.FirstOrDefault(c => c.ClientId == id && c.ClientStatus == true);
        }

        public void AddNewClient(int id,string name)//הוספת לקוח חדש
        {
            _dataContext.clientList.Add(new Client(id,name));
        }

        public void AddTicketToClient(Ticket ticket) // הכנסת כרטיס ללקוח
        {          
            _dataContext.clientList.FirstOrDefault(c => c.ClientId == ticket.ClientId).ClientTicketList.Add(ticket);
        }

        //public void DeleteTicketToClient(Ticket ticket); //מחיקת כרטיס ללקוח  
    }
}
