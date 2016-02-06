using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Truewheelers.Models;

namespace Truewheelers.Models
{
    public class TruewheelersDbContext : IdentityDbContext<ApplicationUser>
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
            base.OnModelCreating(builder);
        }

        public DbSet<Bicycles> Bicycles { get; set; }

        public DbSet<ShoppingCart> ShoppingCart { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
