using System;
using System.Collections.Generic;
using CRUDVoitureDb.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace CRUDVoitureDb.Models;

public partial class VoitureDBContext : DbContext
{
	public VoitureDBContext()
	{
	}

	public VoitureDBContext(DbContextOptions<VoitureDBContext> options)
		: base(options)
	{
	}

	public virtual DbSet<Voiture> Voitures { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySQL("server=localhost;user=root;database=voituredb;port=3306;ssl mode=none");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Voiture>(entity =>
		{
			entity.HasKey(e => e.IdVoiture).HasName("PRIMARY");

			entity.ToTable("voiture");

			entity.Property(e => e.IdVoiture)
				.HasColumnType("int(11)")
				.HasColumnName("Id_Voiture");
			entity.Property(e => e.Km)
				.HasColumnType("int(11)")
				.HasColumnName("km");
			entity.Property(e => e.Marque)
				.HasMaxLength(50)
				.HasColumnName("marque");
			entity.Property(e => e.Model)
				.HasMaxLength(50)
				.HasColumnName("model");
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
