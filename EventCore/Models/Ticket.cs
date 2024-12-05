using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Tracing;

namespace Event.Core.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int EventCode { get; set; }
        public string EventName { get; set; }


    }
}
