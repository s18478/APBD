using Classes11.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Classes11.Models
{
    public class ClinicDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicament { get; set; }
        protected ClinicDbContext()
        {
        }

        public ClinicDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DoctorEfConfig());
            modelBuilder.ApplyConfiguration(new PrescriptionEfConfig());
            modelBuilder.ApplyConfiguration(new PatientEfConfig());
            modelBuilder.ApplyConfiguration(new MedicamentEfConfig());
            modelBuilder.ApplyConfiguration(new PrescriptionMedicamentEfConfig());
        }
    }
}