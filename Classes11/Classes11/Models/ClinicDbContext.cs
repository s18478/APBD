using Classes11.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Classes11.Models
{
    public class ClinicDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        protected ClinicDbContext()
        {
        }

        public ClinicDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DoctorEfConfiguration());
        }
    }
}