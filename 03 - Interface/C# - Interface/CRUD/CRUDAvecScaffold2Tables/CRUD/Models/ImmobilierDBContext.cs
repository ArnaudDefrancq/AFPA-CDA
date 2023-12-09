using System;
using System.Collections.Generic;
using CRUD.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Models;

public partial class ImmobilierDBContext : DbContext
{
    public ImmobilierDBContext()
    {
    }

    public ImmobilierDBContext(DbContextOptions<ImmobilierDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appartement> Appartements { get; set; }

    public virtual DbSet<Categorie> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
 => optionsBuilder.UseMySQL("Server=localhost;User=root;Database=immobilierdb;Port=3306;SslMode=None;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appartement>(entity =>
        {
            entity.HasKey(e => e.IdAppartement).HasName("PRIMARY");

            entity.ToTable("appartement");

            entity.HasIndex(e => e.Type, "Type");

            entity.Property(e => e.Adresse).HasMaxLength(50);
            entity.Property(e => e.Ville).HasMaxLength(50);

            entity.HasOne(d => d.CategorieAppartement).WithMany(p => p.Appartements)
                .HasForeignKey(d => d.Type)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appartement_ibfk_1");
        });

        modelBuilder.Entity<Categorie>(entity =>
        {
            entity.HasKey(e => e.IdCategorie).HasName("PRIMARY");

            entity.ToTable("categorie");

            entity.Property(e => e.TypeAppartement)
                .HasMaxLength(50)
                .HasColumnName("typeAppartement");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
