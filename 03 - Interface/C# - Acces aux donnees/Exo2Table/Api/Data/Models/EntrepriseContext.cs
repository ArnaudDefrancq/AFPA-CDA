using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Models;

public partial class EntrepriseContext : DbContext
{
    public EntrepriseContext()
    {
    }

    public EntrepriseContext(DbContextOptions<EntrepriseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employe> Employes { get; set; }

    public virtual DbSet<Voiturefonction> Voiturefonctions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("Name=Default");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employe>(entity =>
        {
            entity.HasKey(e => e.IdEmploye).HasName("PRIMARY");

            entity.ToTable("employe");

            entity.HasIndex(e => e.IdVoitureFonction, "IdVoitureFonction");

            entity.Property(e => e.IdEmploye).HasColumnType("int(11)");
            entity.Property(e => e.Age).HasColumnType("int(11)");
            entity.Property(e => e.IdVoitureFonction).HasColumnType("int(11)");
            entity.Property(e => e.Nom).HasMaxLength(50);
            entity.Property(e => e.Prenom).HasMaxLength(50);

            entity.HasOne(d => d.IdVoitureFonctionNavigation).WithMany(p => p.Employes)
                .HasForeignKey(d => d.IdVoitureFonction)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("IdVoitureFonction");
        });

        modelBuilder.Entity<Voiturefonction>(entity =>
        {
            entity.HasKey(e => e.IdVoitureFonction).HasName("PRIMARY");

            entity.ToTable("voiturefonction");

            entity.Property(e => e.IdVoitureFonction).HasColumnType("int(11)");
            entity.Property(e => e.Kilometre).HasColumnType("int(11)");
            entity.Property(e => e.Marque).HasMaxLength(50);
            entity.Property(e => e.Model).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
