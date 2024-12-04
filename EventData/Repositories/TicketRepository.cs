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
    public class TicketRepository:ITicketRepository
    {
        private readonly IDataContext _dataContext;

        public TicketRepository(IDataContext context)
        {
            _dataContext = context;
        }

        //public void BuyTicket(Ticket ticket) //קנית כרטיס
        //{
        //    _dataContext.clientList.FirstOrDefault(c => c.ClientId == ticket.ClientId).ClientTicketList.Add(ticket);
        //}
    }
}
