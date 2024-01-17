﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web_API_Clinica.Models;

#nullable disable

namespace Web_API_Clinica.Migrations
{
    [DbContext(typeof(ClinicaContext))]
    [Migration("20240117140541_Genero")]
    partial class Genero
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Web_API_Clinica.Models.Especialidad", b =>
                {
                    b.Property<int>("EspecialidadID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EspecialidadID"));

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EspecialidadID");

                    b.ToTable("Especialidades");
                });

            modelBuilder.Entity("Web_API_Clinica.Models.Factura", b =>
                {
                    b.Property<int>("FacturaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FacturaID"));

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("FechaEmision")
                        .HasColumnType("datetime2");

                    b.Property<int>("MedicoID")
                        .HasColumnType("int");

                    b.Property<int>("PacienteID")
                        .HasColumnType("int");

                    b.HasKey("FacturaID");

                    b.HasIndex("MedicoID");

                    b.HasIndex("PacienteID");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("Web_API_Clinica.Models.Medico", b =>
                {
                    b.Property<int>("MedicoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicoID"));

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("CostoConsulta")
                        .HasColumnType("decimal(8,2)");

                    b.Property<int>("EspecialidadID")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MedicoID");

                    b.HasIndex("EspecialidadID");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("Web_API_Clinica.Models.ObraSocial", b =>
                {
                    b.Property<int>("ObraSocialID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ObraSocialID"));

                    b.Property<decimal>("Cobertura")
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ObraSocialID");

                    b.ToTable("ObrasSociales");
                });

            modelBuilder.Entity("Web_API_Clinica.Models.Paciente", b =>
                {
                    b.Property<int>("PacienteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PacienteID"));

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ObraSocialID")
                        .HasColumnType("int");

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PacienteID");

                    b.HasIndex("ObraSocialID");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("Web_API_Clinica.Models.Turno", b =>
                {
                    b.Property<int>("TurnoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TurnoID"));

                    b.Property<int>("Duracion")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<int>("MedicoID")
                        .HasColumnType("int");

                    b.Property<int>("PacienteID")
                        .HasColumnType("int");

                    b.HasKey("TurnoID");

                    b.HasIndex("MedicoID");

                    b.HasIndex("PacienteID");

                    b.ToTable("Turnos");
                });

            modelBuilder.Entity("Web_API_Clinica.Models.Factura", b =>
                {
                    b.HasOne("Web_API_Clinica.Models.Medico", "Medico")
                        .WithMany()
                        .HasForeignKey("MedicoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web_API_Clinica.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medico");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("Web_API_Clinica.Models.Medico", b =>
                {
                    b.HasOne("Web_API_Clinica.Models.Especialidad", "Especialidad")
                        .WithMany()
                        .HasForeignKey("EspecialidadID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especialidad");
                });

            modelBuilder.Entity("Web_API_Clinica.Models.Paciente", b =>
                {
                    b.HasOne("Web_API_Clinica.Models.ObraSocial", "ObraSocial")
                        .WithMany()
                        .HasForeignKey("ObraSocialID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ObraSocial");
                });

            modelBuilder.Entity("Web_API_Clinica.Models.Turno", b =>
                {
                    b.HasOne("Web_API_Clinica.Models.Medico", "Medico")
                        .WithMany("Turno")
                        .HasForeignKey("MedicoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web_API_Clinica.Models.Paciente", "Paciente")
                        .WithMany("Turno")
                        .HasForeignKey("PacienteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medico");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("Web_API_Clinica.Models.Medico", b =>
                {
                    b.Navigation("Turno");
                });

            modelBuilder.Entity("Web_API_Clinica.Models.Paciente", b =>
                {
                    b.Navigation("Turno");
                });
#pragma warning restore 612, 618
        }
    }
}