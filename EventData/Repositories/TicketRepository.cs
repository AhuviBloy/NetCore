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
    public class TicketRepository:ITicketRepository
    {
        private readonly DataContext _dataContext;

        public TicketRepository(DataContext context)
        {
            _dataContext = context;
        }

        public void AddTicketToDb(Ticket ticket) //קנית כרטיס
        {
            _dataContext.ticketDbSet.Add(ticket);
            _dataContext.SaveChanges();
        }
    }
}
