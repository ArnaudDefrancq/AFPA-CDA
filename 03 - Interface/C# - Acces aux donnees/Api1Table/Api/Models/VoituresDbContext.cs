using System;
using System.Collections.Generic;
using Api.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Models;

public partial class VoituresDbContext : DbContext
{
    public VoituresDbContext()
    {
    }

    public VoituresDbContext(DbContextOptions<VoituresDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Voiture> Voitures { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("Name=Default");

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
