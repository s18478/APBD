using System.Collections.Generic;
using Classes11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Classes11.Configurations
{
    public class MedicamentEfConfig : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder
                .HasKey("IdMedicament");

            builder
                .Property(m => m.IdMedicament)
                .ValueGeneratedOnAdd();

            builder
                .Property(m => m.Name)
                .HasMaxLength(100);
            
            builder
                .Property(m => m.Description)
                .HasMaxLength(100);
            
            builder
                .Property(m => m.Type)
                .HasMaxLength(100);

            var medicaments = new List<Medicament>()
            {
                new Medicament
                {
                    IdMedicament = 1, Name = "APAP Noc", Description = "Stosować tylko w nocy", Type = "Tabletki"
                },
                new Medicament
                {
                    IdMedicament = 2, Name = "APAP Dzień", Description = "Stosować tylko w dzień", Type = "Tabletki"
                },
                new Medicament
                {
                    IdMedicament = 3, Name = "Alertec", Description = "Na alergie", Type = "Płyn"
                }
            };

            builder
                .HasData(medicaments);
        }
    }
}