using EventCore.Class;

namespace EventCore.Interface
{
    public interface IDataContext
    {

        List<Ticket> ticketList { get; set; }
        List<Client> clientList { get; set; }
        List<Event> eventList { get; set; }
        List<Producer> producersList { get; set; }
    }
}
