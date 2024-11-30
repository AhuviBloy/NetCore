using Event.Core.Models;

namespace Event.Core.Interface
{
    public interface IDataContext
    {

        List<Ticket> ticketList { get; set; }
        List<Client> clientList { get; set; }
        List<Models.SingleEvent> eventList { get; set; }
        List<Producer> producersList { get; set; }
    }
}
