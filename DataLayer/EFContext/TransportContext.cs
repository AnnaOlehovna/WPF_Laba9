using DataLayer.Entities;
using System.Data.Entity;

namespace DataLayer.EFContext
{
    class TransportsContext: DbContext
    {
        public TransportsContext(string name) : base(name)
        {
            Database.SetInitializer(new TransportInitializer());
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Transport> Transports { get; set; }
    }
}
