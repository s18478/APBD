﻿// <auto-generated />
using System;
using Classes11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Classes11.Migrations
{
    [DbContext(typeof(ClinicDbContext))]
    [Migration("20200525225638_AddedMedicamentPrescriptionTable")]
    partial class AddedMedicamentPrescriptionTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Classes11.Models.Doctor", b =>
                {
                    b.Property<int>("IdDoctor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdDoctor");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            IdDoctor = 1,
                            Email = "kowalski@poczta.pl",
                            FirstName = "Jan",
                            LastName = "Kowalski"
                        },
                        new
                        {
                            IdDoctor = 2,
                            Email = "nowak@poczta.pl",
                            FirstName = "Andrzej",
                            LastName = "Nowak"
                        },
                        new
                        {
                            IdDoctor = 3,
                            Email = "borkowska@poczta.pl",
                            FirstName = "Antonina",
                            LastName = "Borkowska"
                        });
                });

            modelBuilder.Entity("Classes11.Models.Medicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdMedicament");

                    b.ToTable("Medicaments");

                    b.HasData(
                        new
                        {
                            IdMedicament = 1,
                            Description = "Stosować tylko w nocy",
                            Name = "APAP Noc",
                            Type = "Tabletki"
                        },
                        new
                        {
                            IdMedicament = 2,
                            Description = "Stosować tylko w dzień",
                            Name = "APAP Dzień",
                            Type = "Tabletki"
                        },
                        new
                        {
                            IdMedicament = 3,
                            Description = "Na alergie",
                            Name = "Alertec",
                            Type = "Płyn"
                        });
                });

            modelBuilder.Entity("Classes11.Models.Patient", b =>
                {
                    b.Property<int>("IdPatient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdPatient");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            IdPatient = 1,
                            Birthdate = new DateTime(1992, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Stanisław",
                            LastName = "Nowak"
                        },
                        new
                        {
                            IdPatient = 2,
                            Birthdate = new DateTime(1990, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Roman",
                            LastName = "Malinowski"
                        },
                        new
                        {
                            IdPatient = 3,
                            Birthdate = new DateTime(1972, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Jadwiga",
                            LastName = "Kowalska"
                        });
                });

            modelBuilder.Entity("Classes11.Models.Prescription", b =>
                {
                    b.Property<int>("IdPrescription")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("date");

                    b.Property<int>("IdDoctor")
                        .HasColumnType("int");

                    b.Property<int>("IdPatient")
                        .HasColumnType("int");

                    b.HasKey("IdPrescription");

                    b.HasIndex("IdDoctor");

                    b.HasIndex("IdPatient");

                    b.ToTable("Prescriptions");

                    b.HasData(
                        new
                        {
                            IdPrescription = 1,
                            Date = new DateTime(2020, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2020, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdDoctor = 2,
                            IdPatient = 1
                        },
                        new
                        {
                            IdPrescription = 2,
                            Date = new DateTime(2020, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2020, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdDoctor = 1,
                            IdPatient = 2
                        },
                        new
                        {
                            IdPrescription = 3,
                            Date = new DateTime(2020, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2020, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdDoctor = 3,
                            IdPatient = 3
                        });
                });

            modelBuilder.Entity("Classes11.Models.PrescriptionMedicament", b =>
                {
                    b.Property<int>("IdPrescription")
                        .HasColumnType("int");

                    b.Property<int>("IdMedicament")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("Dose")
                        .HasColumnType("int");

                    b.HasKey("IdPrescription", "IdMedicament");

                    b.HasIndex("IdMedicament");

                    b.ToTable("PrescriptionMedicament");

                    b.HasData(
                        new
                        {
                            IdPrescription = 1,
                            IdMedicament = 1,
                            Details = "Po kolacji",
                            Dose = 1
                        },
                        new
                        {
                            IdPrescription = 2,
                            IdMedicament = 2,
                            Details = "Po śniadaniu i obiedzie",
                            Dose = 2
                        },
                        new
                        {
                            IdPrescription = 3,
                            IdMedicament = 3,
                            Details = "3 razy dziennie",
                            Dose = 3
                        });
                });

            modelBuilder.Entity("Classes11.Models.Prescription", b =>
                {
                    b.HasOne("Classes11.Models.Doctor", "Doctor")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdDoctor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Classes11.Models.Patient", "Patient")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdPatient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Classes11.Models.PrescriptionMedicament", b =>
                {
                    b.HasOne("Classes11.Models.Medicament", "Medicament")
                        .WithMany("PrescriptionMedicament")
                        .HasForeignKey("IdMedicament")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Classes11.Models.Prescription", "Prescription")
                        .WithMany("PrescriptionMedicament")
                        .HasForeignKey("IdPrescription")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
