using Event.Core.Interface;
using Event.Core.Models;
using Event.Core.Repositories;
using EventCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Data.Repositories
{
    public class ClientRepository:IClientRepository
    {
        private readonly DataContext _dataContext;

        public ClientRepository(DataContext context)
        {
            _dataContext = context;
        }

        public List<Client> GetAllClients()
        {
            return _dataContext.clientDbSet.ToList();
        }

        public Client GetClientById(int id)
        {
           return _dataContext.clientDbSet.FirstOrDefault(c => c.ClientId == id && c.ClientStatus == true);
        }

        public void AddNewClient(Client client)//הוספת לקוח חדש
        {
            _dataContext.clientDbSet.Add(client);
            _dataContext.SaveChanges();
        }

        public void AddTicketToClient(Ticket ticket) // הכנסת כרטיס ללקוח
        {
            var client = _dataContext.clientDbSet.FirstOrDefault(c => c.ClientId == ticket.ClientId);

            if (client.ClientTicketList != null)
            {
                client.ClientTicketList.Add(ticket);
            }
            else {
                client.ClientTicketList = new List<Ticket> { ticket };                   
            }

            _dataContext.SaveChanges();
        }

        //public void DeleteTicketToClient(Ticket ticket); //מחיקת כרטיס ללקוח  
    }
}
