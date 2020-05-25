using System;
using System.Collections.Generic;
using Classes11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Classes11.Configurations
{
    public class PatientEfConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder
                .HasKey(p => p.IdPatient);

            builder
                .Property(p => p.IdPatient)
                .ValueGeneratedOnAdd();
            
            builder
                .Property(p => p.FirstName)
                .HasMaxLength(100);

            builder
                .Property(p => p.LastName)
                .HasMaxLength(100);
            
            builder
                .Property(p => p.Birthdate)
                .HasColumnType("date");

            var patients = new List<Patient>()
            {
                new Patient { IdPatient = 1, FirstName = "Stanisław", LastName = "Nowak", Birthdate = new DateTime(1992, 12, 12)},
                new Patient { IdPatient = 2, FirstName = "Roman", LastName = "Malinowski", Birthdate = new DateTime(1990, 10, 24)},
                new Patient { IdPatient = 3, FirstName = "Jadwiga", LastName = "Kowalska", Birthdate = new DateTime(1972, 6, 13)}
            };

            builder
                .HasData(patients);
        }
    }
}