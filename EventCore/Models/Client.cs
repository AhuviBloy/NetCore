namespace Event.Core.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public bool ClientStatus { get; set; }
        public List<Ticket> ClientTicketList { get; set; }

        public Client(int id,string name)
        {
            ClientId = id;
            ClientName = name;
            ClientStatus = true;
            ClientTicketList = new List<Ticket>();
        }
    }
}
