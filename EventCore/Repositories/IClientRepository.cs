using Event.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Core.Repositories
{
    public interface IClientRepository
    {
        public List<Client> GetAllClients(); //קבלת כל הלקוחות
        public Client GetClientById(int id); //קבלת פרטי לקוח
        public void AddNewClient(Client client); // (הוספת לקוח חדש (במקרה שקנה כרטיס
        public void AddTicketToClient(Ticket ticket); // הכנסת כרטיס ללקוח

        //public void DeleteTicketToClient(Ticket ticket); //מחיקת כרטיס ללקוח  
    }
}
