using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Tracing;

namespace Event.Core.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ClientId")]
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public Client Client { get; set; }
        public int EventId { get; set; }
        //public SingleEvent Event { get; set; }
    }
}
