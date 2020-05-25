using System;
using System.Collections.Generic;
using Classes11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Classes11.Configurations
{
    public class PrescriptionMedicamentEfConfig : IEntityTypeConfiguration<PrescriptionMedicament>
    {
        public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
        {
            builder
                .HasKey(e => new {e.IdPrescription, e.IdMedicament});

            builder
                .Property(e => e.Details)
                .HasMaxLength(100);
            
            builder
                .HasOne(e => e.Medicament)
                .WithMany(m => m.PrescriptionMedicament)
                .HasForeignKey(e => e.IdMedicament);
            
            builder
                .HasOne(e => e.Prescription)
                .WithMany(p => p.PrescriptionMedicament)
                .HasForeignKey(e => e.IdPrescription);

            var list = new List<PrescriptionMedicament>()
            {
                new PrescriptionMedicament()
                {
                    IdMedicament = 1, IdPrescription = 1, Dose = 1, Details = "Po kolacji"
                    
                },
                new PrescriptionMedicament()
                {
                    IdMedicament = 2, IdPrescription = 2, Dose = 2, Details = "Po śniadaniu i obiedzie"
                },
                new PrescriptionMedicament()
                {
                    IdMedicament = 3, IdPrescription = 3, Dose = 3, Details = "3 razy dziennie"
                },
            };

            builder
                .HasData(list);
        }
    }
}