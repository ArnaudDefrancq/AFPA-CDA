using System;
using System.Collections.Generic;
using System.Configuration;
using CRUD.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Models;

public partial class medecinedbDBContext : DbContext
{
	public medecinedbDBContext()
	{
	}

	public medecinedbDBContext(DbContextOptions<medecinedbDBContext> options)
		: base(options)
	{
	}

	public virtual DbSet<Medecin> Medecins { get; set; }

	public virtual DbSet<Medicament> Medicaments { get; set; }

	public virtual DbSet<Prescription> Prescriptions { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseMySQL(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
	}


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Medecin>(entity =>
		{
			entity.HasKey(e => e.IdMedecin).HasName("PRIMARY");

			entity.ToTable("medecin");

			entity.Property(e => e.IdMedecin)
				.HasColumnType("int(11)")
				.HasColumnName("Id_Medecin");
			entity.Property(e => e.Age)
				.HasColumnType("int(11)")
				.HasColumnName("age");
			entity.Property(e => e.Nom)
				.HasMaxLength(50)
				.HasColumnName("nom");
			entity.Property(e => e.Prenom)
				.HasMaxLength(50)
				.HasColumnName("prenom");
		});

		modelBuilder.Entity<Medicament>(entity =>
		{
			entity.HasKey(e => e.IdMedicament).HasName("PRIMARY");

			entity.ToTable("medicament");

			entity.Property(e => e.IdMedicament)
				.HasColumnType("int(11)")
				.HasColumnName("Id_Medicament");
			entity.Property(e => e.Entreprise)
				.HasMaxLength(50)
				.HasColumnName("entreprise");
			entity.Property(e => e.NomMedicament)
				.HasMaxLength(50)
				.HasColumnName("nomMedicament");
		});

		modelBuilder.Entity<Prescription>(entity =>
		{
			entity.HasKey(e => e.IdPrescription).HasName("PRIMARY");

			entity.ToTable("prescription");

			entity.HasIndex(e => e.Medoc, "Medoc");

			entity.HasIndex(e => e.Soignant, "Soignant");

			entity.Property(e => e.IdPrescription)
				.HasColumnType("int(11)")
				.HasColumnName("Id_Prescription");
			entity.Property(e => e.DatePrescription)
				.HasColumnType("datetime")
				.HasColumnName("datePrescription");
			entity.Property(e => e.Medoc).HasColumnType("int(11)");
			entity.Property(e => e.Soignant).HasColumnType("int(11)");

			entity.HasOne(d => d.LeMedicament).WithMany(p => p.Prescriptions)
				.HasForeignKey(d => d.Medoc)
				.OnDelete(DeleteBehavior.Restrict)
				.HasConstraintName("prescription_ibfk_2");

			entity.HasOne(d => d.LeSoignant).WithMany(p => p.Prescriptions)
				.HasForeignKey(d => d.Soignant)
				.OnDelete(DeleteBehavior.Restrict)
				.HasConstraintName("prescription_ibfk_1");
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
