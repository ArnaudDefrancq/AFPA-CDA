using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using gestionStock.Models.Data;

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

			entity.HasIndex(e => e.IdCategorie, "articles_ibfk_1");

			entity.Property(e => e.IdArticle).HasColumnType("int(11)");
			entity.Property(e => e.IdCategorie).HasColumnType("int(11)");
			entity.Property(e => e.LibelleArticle).HasMaxLength(100);
			entity.Property(e => e.QuantiteStrockee).HasColumnType("int(11)");

			entity.HasOne(d => d.LaCategorie).WithMany(p => p.LesArticles)
				.HasForeignKey(d => d.IdCategorie)
				.HasConstraintName("articles_ibfk_1");
		});

		modelBuilder.Entity<Categorie>(entity =>
		{
			entity.HasKey(e => e.IdCategorie).HasName("PRIMARY");

			entity.ToTable("categories");

			entity.HasIndex(e => e.IdTypeProduit, "categories_ibfk_1");

			entity.Property(e => e.IdCategorie).HasColumnType("int(11)");
			entity.Property(e => e.IdTypeProduit).HasColumnType("int(11)");
			entity.Property(e => e.LibelleCategorie).HasMaxLength(100);

			entity.HasOne(d => d.LeTypeProduit).WithMany(p => p.LesCategories)
				.HasForeignKey(d => d.IdTypeProduit)
				.HasConstraintName("categories_ibfk_1");
		});

		modelBuilder.Entity<TypesProduit>(entity =>
		{
			entity.HasKey(e => e.IdTypeProduit).HasName("PRIMARY");

			entity.ToTable("typesproduits");

			entity.Property(e => e.IdTypeProduit).HasColumnType("int(11)");
			entity.Property(e => e.LibelleTypeProduit).HasMaxLength(50);
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
