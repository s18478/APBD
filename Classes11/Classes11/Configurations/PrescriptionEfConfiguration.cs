using System;
using System.Collections.Generic;
using Classes11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Classes11.Configurations
{
    public class PrescriptionEfConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder
                .HasKey("IdPrescription");

            builder
                .Property(p => p.IdPrescription)
                .ValueGeneratedOnAdd();

            builder
                .Property(p => p.Date)
                .HasColumnType("date");
            
            builder
                .Property(p => p.DueDate)
                .HasColumnType("date");

            builder
                .HasOne(p => p.Doctor)
                .WithMany(d => d.Prescriptions)
                .HasForeignKey(p => p.IdDoctor);
            
            builder
                .HasOne(p => p.Patient)
                .WithMany(patient => patient.Prescriptions)
                .HasForeignKey(p => p.IdPatient);

            var prescriptions = new List<Prescription>()
            {
                new Prescription
                {
                    IdPrescription = 1, Date = new DateTime(2020, 5, 16), DueDate = new DateTime(2020, 5, 23),
                    IdPatient = 1, IdDoctor = 2
                },
                new Prescription
                {
                    IdPrescription = 2, Date = new DateTime(2020, 4, 11), DueDate = new DateTime(2020, 5, 11),
                    IdPatient = 2, IdDoctor = 1
                },
                new Prescription
                {
                    IdPrescription = 3, Date = new DateTime(2020, 5, 8), DueDate = new DateTime(2020, 5, 22),
                    IdPatient = 3, IdDoctor = 3
                },
            };

            builder
                .HasData(prescriptions);
        }
    }
}