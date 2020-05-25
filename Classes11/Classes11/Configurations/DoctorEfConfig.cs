using System.Collections.Generic;
using Classes11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Classes11.Configurations
{
    public class DoctorEfConfig : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder
                .HasKey(d => d.IdDoctor);

            builder
                .Property(d => d.IdDoctor)
                .ValueGeneratedOnAdd();
            
            builder
                .Property(d => d.FirstName)
                .HasMaxLength(100);

            builder
                .Property(d => d.LastName)
                .HasMaxLength(100);

            builder
                .Property(d => d.Email)
                .HasMaxLength(100);

            var doctors = new List<Doctor>()
            {
                new Doctor { IdDoctor = 1, FirstName = "Jan", LastName = "Kowalski", Email = "kowalski@poczta.pl" },
                new Doctor { IdDoctor = 2, FirstName = "Andrzej", LastName = "Nowak", Email = "nowak@poczta.pl" },
                new Doctor { IdDoctor = 3, FirstName = "Antonina", LastName = "Borkowska", Email = "borkowska@poczta.pl" },
            };

            builder
                .HasData(doctors);
        }
    }
}