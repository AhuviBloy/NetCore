namespace Event.Core.Models
{
    public class Ticket
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int EventCode { get; set; }
        public string EventName { get; set; }

        public Ticket()
        {

        }
    }
}
