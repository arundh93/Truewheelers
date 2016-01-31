using Microsoft.Data.Entity;

namespace Truewheelers.Models
{
    public class TruewheelersDbContext : DbContext
    {
        private static bool _created = false;

        public TruewheelersDbContext()
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }

        public DbSet<Bicycles> Bicycles { get; set; }
    }
}
