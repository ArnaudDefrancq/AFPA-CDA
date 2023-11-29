using System;
using System.Collections.Generic;
using Api.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Models;

public partial class NoelDBContext : DbContext
{
	public NoelDBContext()
	{
	}

	public NoelDBContext(DbContextOptions<NoelDBContext> options)
		: base(options)
	{
	}

	public virtual DbSet<Cadeau> Cadeaus { get; set; }

	public virtual DbSet<Enfant> Enfants { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder.UseMySQL("Name=Default");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Cadeau>(entity =>
		{
			entity.HasKey(e => e.IdCadeau).HasName("PRIMARY");

			entity.ToTable("cadeau");

			entity.Property(e => e.IdCadeau)
				.HasColumnType("int(11)")
				.HasColumnName("Id_cadeau");
			entity.Property(e => e.Nom)
				.HasMaxLength(50)
				.HasColumnName("nom");
			entity.Property(e => e.Prix)
				.HasColumnType("int(11)")
				.HasColumnName("prix");
		});

		modelBuilder.Entity<Enfant>(entity =>
		{
			entity.HasKey(e => e.IdEnfant).HasName("PRIMARY");

			entity.ToTable("enfant");

			entity.HasIndex(e => e.IdCadeau, "Id_cadeau");

			entity.Property(e => e.IdEnfant)
				.HasColumnType("int(11)")
				.HasColumnName("Id_Enfant");
			entity.Property(e => e.Age)
				.HasColumnType("int(11)")
				.HasColumnName("age");
			entity.Property(e => e.IdCadeau)
				.HasColumnType("int(11)")
				.HasColumnName("Id_cadeau");
			entity.Property(e => e.Nom)
				.HasMaxLength(50)
				.HasColumnName("nom");
			entity.Property(e => e.Prenom)
				.HasMaxLength(50)
				.HasColumnName("prenom");

			entity.HasOne(d => d.LeCadeau).WithMany(p => p.Enfants)
				.HasForeignKey(d => d.IdCadeau)
				.OnDelete(DeleteBehavior.Restrict)
				.HasConstraintName("enfant_ibfk_1");
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
