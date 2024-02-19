using Microsoft.EntityFrameworkCore;

namespace SweetStore.Models
{
    public class SweetStoreContext : DbContext
    {
        public DbSet<Treat> Treats { get; set; }
        public DbSet<Flavor> Flavors { get; set; }
        public DbSet<TreatFlavor> TreatFlavors { get; set; }

        public SweetStoreContext(DbContextOptions<SweetStoreContext> options) : base(options) { }
    }
}