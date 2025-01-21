using Event.Core.Interface;
using Event.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EventCore.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<Ticket> ticketDbSet { get; set; }
        public DbSet<Client> clientDbSet { get; set; }
        public DbSet<SingleEvent> eventDbSet { get; set; }
        public DbSet<Producer> producersDbSet { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=sample_db");
        }
        /*Database=sample_db*/

    }
}
