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
            return _dataContext.clientDbSet.ToList();
        }

        public Client GetClientById(int id)
        {
           return _dataContext.clientDbSet.FirstOrDefault(c => c.ClientId == id && c.ClientStatus == true);
        }

        public void AddNewClient(int id,string name)//הוספת לקוח חדש
        {
            _dataContext.clientDbSet.Add(new Client() { ClientId=id,ClientName=name,ClientTicketList=new List<Ticket>(),ClientStatus=true});
        }

        public void AddTicketToClient(Ticket ticket) // הכנסת כרטיס ללקוח
        {          
            _dataContext.clientDbSet.FirstOrDefault(c => c.ClientId == ticket.ClientId).ClientTicketList.Add(ticket);
        }

        //public void DeleteTicketToClient(Ticket ticket); //מחיקת כרטיס ללקוח  
    }
}
