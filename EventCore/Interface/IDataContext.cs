using Event.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Event.Core.Interface
{
    public interface IDataContext
    {
        DbSet<Ticket> ticketDbSet { get; set; }
        DbSet<Client> clientDbSet { get; set; }
        DbSet<SingleEvent> eventDbSet { get; set; }
        DbSet<Producer> producersDbSet { get; set; }
    }
}
