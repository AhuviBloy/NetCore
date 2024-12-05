using System.ComponentModel.DataAnnotations;

namespace Event.Core.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public bool ClientStatus { get; set; }
        public List<Ticket> ClientTicketList { get; set; }


    }
}
