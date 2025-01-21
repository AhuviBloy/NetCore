using Event.Core.Models;
using GlaTicket.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Core.Services
{
    public interface ITicketService
    {
        public void BuyTicket(TicketPostDTO ticket); //קנית כרטיס
    }
}
