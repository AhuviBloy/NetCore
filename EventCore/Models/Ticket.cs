using System.Diagnostics.Tracing;

namespace Event.Core.Models
{
    public class Ticket
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int EventCode { get; set; }
        public string EventName { get; set; }


        public Ticket(int cId,string cName ,int eCode,string eName)
        {
            ClientId = cId;
            ClientName = cName;
            EventCode= eCode;
            EventName = eName;

        }
    }
}
