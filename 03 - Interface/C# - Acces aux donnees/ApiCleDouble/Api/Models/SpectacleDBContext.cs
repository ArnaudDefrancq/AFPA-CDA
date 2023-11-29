using System;
using System.Collections.Generic;
using Api.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Models;

public partial class SpectacleDBContext : DbContext
{
	public SpectacleDBContext()
	{
	}

	public SpectacleDBContext(DbContextOptions<SpectacleDBContext> options)
		: base(options)
	{
	}

	public virtual DbSet<Acheter> Acheters { get; set; }

	public virtual DbSet<Client> Clients { get; set; }

	public virtual DbSet<Prestation> Prestations { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder.UseMySQL("Name=Default");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Acheter>(entity =>
		{
			entity.HasKey(e => new { e.IdPrestation, e.IdClient }).HasName("PRIMARY");

			entity.ToTable("acheter");

			entity.HasIndex(e => e.IdClient, "Id_client");

			entity.Property(e => e.IdPrestation)
				.HasColumnType("int(11)")
				.HasColumnName("Id_prestation");
			entity.Property(e => e.IdClient)
				.HasColumnType("int(11)")
				.HasColumnName("Id_client");
			entity.Property(e => e.DatePresta)
				.HasColumnType("int(11)")
				.HasColumnName("datePresta");

			entity.HasOne(d => d.ListClients).WithMany(p => p.Acheters)
				.HasForeignKey(d => d.IdClient)
				.OnDelete(DeleteBehavior.Restrict)
				.HasConstraintName("acheter_ibfk_2");

			entity.HasOne(d => d.ListPrestations).WithMany(p => p.Acheters)
				.HasForeignKey(d => d.IdPrestation)
				.OnDelete(DeleteBehavior.Restrict)
				.HasConstraintName("acheter_ibfk_1");
		});

		modelBuilder.Entity<Client>(entity =>
		{
			entity.HasKey(e => e.IdClient).HasName("PRIMARY");

			entity.ToTable("client");

			entity.Property(e => e.IdClient)
				.HasColumnType("int(11)")
				.HasColumnName("Id_client");
			entity.Property(e => e.Nom)
				.HasMaxLength(50)
				.HasColumnName("nom");
			entity.Property(e => e.Prenom)
				.HasMaxLength(50)
				.HasColumnName("prenom");
		});

		modelBuilder.Entity<Prestation>(entity =>
		{
			entity.HasKey(e => e.IdPrestation).HasName("PRIMARY");

			entity.ToTable("prestation");

			entity.Property(e => e.IdPrestation)
				.HasColumnType("int(11)")
				.HasColumnName("Id_prestation");
			entity.Property(e => e.Nom)
				.HasMaxLength(50)
				.HasColumnName("nom");
			entity.Property(e => e.Prix)
				.HasMaxLength(50)
				.HasColumnName("prix");
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
