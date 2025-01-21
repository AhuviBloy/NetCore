using Event.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlaTicket.Core.DTO
{
    public class ClientGetDTO
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public bool ClientStatus { get; set; }
        public List<Ticket> ClientTicketList { get; set; } = new List<Ticket>() { };
    }
}
