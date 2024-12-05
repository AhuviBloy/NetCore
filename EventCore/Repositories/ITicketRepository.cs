using Event.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Core.Repositories
{
    public interface ITicketRepository
    {
        public void AddTicketToDb(Ticket ticket); //קנית כרטיס
    }
}
