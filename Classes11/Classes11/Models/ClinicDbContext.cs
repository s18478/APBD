using Microsoft.EntityFrameworkCore;

namespace Classes11.Models
{
    public class ClinicDbContext : DbContext
    {
        protected ClinicDbContext()
        {
        }

        public ClinicDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
    }
}