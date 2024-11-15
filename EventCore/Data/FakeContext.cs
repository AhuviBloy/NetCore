﻿using EventCore.Class;
using EventCore.Interface;

namespace EventCore.Data
{
    public class FakeContext : IDataContext
    {
        public List<Ticket> ticketList { get; set; }
        public List<Client> clientList { get; set; }
        public List<Event> eventList { get; set; }
        public List<Producer> producersList { get; set; }

        public FakeContext()
        {
            clientList = new List<Client>();
            ticketList = new List<Ticket>();
            eventList = new List<Event>();
            producersList = new List<Producer>();
        }
    }
}
