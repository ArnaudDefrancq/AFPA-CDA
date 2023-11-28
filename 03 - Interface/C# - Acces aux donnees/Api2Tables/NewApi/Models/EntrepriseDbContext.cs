using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NewApi.Models.Data;

namespace NewApi.Models;

public partial class EntrepriseDbContext : DbContext
{
    public EntrepriseDbContext()
    {
    }

    public EntrepriseDbContext(DbContextOptions<EntrepriseDbContext> options)
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

            entity.Property(e => e.IdEmploye)
                .HasColumnType("int(11)")
                .HasColumnName("Id_Employe");
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

        modelBuilder.Entity<Voiturefonction>(entity =>
        {
            entity.HasKey(e => e.IdVoitures).HasName("PRIMARY");

            entity.ToTable("voiturefonction");

            entity.HasIndex(e => e.IdEmploye, "Id_Employe");

            entity.Property(e => e.IdVoitures)
                .HasColumnType("int(11)")
                .HasColumnName("Id_Voitures");
            entity.Property(e => e.IdEmploye)
                .HasColumnType("int(11)")
                .HasColumnName("Id_Employe");
            entity.Property(e => e.Km)
                .HasColumnType("int(11)")
                .HasColumnName("km");
            entity.Property(e => e.Marque)
                .HasMaxLength(50)
                .HasColumnName("marque");
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .HasColumnName("model");

            entity.HasOne(d => d.IdEmployeNavigation).WithMany(p => p.Voiturefonctions)
                .HasForeignKey(d => d.IdEmploye)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("voiturefonction_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
