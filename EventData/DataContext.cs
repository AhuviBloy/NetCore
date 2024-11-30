using Event.Core.Interface;
using Event.Core.Models;

namespace EventCore.Data
{
    public class DataContext : IDataContext
    {
        public List<Ticket> ticketList { get; set; }
        public List<Client> clientList { get; set; }
        public List<SingleEvent> eventList { get; set; }
        public List<Producer> producersList { get; set; }

        public DataContext()
        {
            clientList = new List<Client>();
            ticketList = new List<Ticket>();
            eventList = new List<SingleEvent>() ;
            producersList = new List<Producer>();
        }
    }
}
