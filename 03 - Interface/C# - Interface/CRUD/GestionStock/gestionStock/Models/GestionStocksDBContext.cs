using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using gestionStock.Models.Data;
using System.Configuration;

namespace gestionStock.Models;

public partial class GestionStocksDBContext : DbContext
{
	public GestionStocksDBContext()
	{
	}

	public GestionStocksDBContext(DbContextOptions<GestionStocksDBContext> options)
		: base(options)
	{
	}

	public virtual DbSet<Article> Articles { get; set; }

	public virtual DbSet<Categorie> Categories { get; set; }

	public virtual DbSet<TypesProduit> Typesproduits { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseMySQL(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Article>(entity =>
		{
			entity.HasKey(e => e.IdArticle).HasName("PRIMARY");

			entity.ToTable("articles");

			entity.HasIndex(e => e.IdCategorie, "IdCategorie");

			entity.Property(e => e.LibelleArticle).HasMaxLength(100);

			entity.HasOne(d => d.LaCategorie).WithMany(p => p.LesArticles)
				.HasForeignKey(d => d.IdCategorie)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("articles_ibfk_1");
		});

		modelBuilder.Entity<Categorie>(entity =>
		{
			entity.HasKey(e => e.IdCategorie).HasName("PRIMARY");

			entity.ToTable("categories");

			entity.HasIndex(e => e.IdTypeProduit, "IdTypeProduit");

			entity.Property(e => e.LibelleCategorie).HasMaxLength(100);

			entity.HasOne(d => d.LeTypeProduit).WithMany(p => p.LesCategories)
				.HasForeignKey(d => d.IdTypeProduit)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("categories_ibfk_1");
		});

		modelBuilder.Entity<TypesProduit>(entity =>
		{
			entity.HasKey(e => e.IdTypeProduit).HasName("PRIMARY");

			entity.ToTable("typesproduits");

			entity.Property(e => e.LibelleTypeProduit).HasMaxLength(50);
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
