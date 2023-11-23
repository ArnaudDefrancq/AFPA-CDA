using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RecupDonnee.Models.Data;

public partial class PersonnesDbContext : DbContext
{
    public PersonnesDbContext()
    {
    }

    public PersonnesDbContext(DbContextOptions<PersonnesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

    public virtual DbSet<Personne> Personnes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("Name=Default");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Efmigrationshistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__efmigrationshistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Personne>(entity =>
        {
            entity.HasKey(e => e.IdPersonne).HasName("PRIMARY");

            entity.ToTable("personnes");

            entity.Property(e => e.IdPersonne).HasColumnType("int(11)");
            entity.Property(e => e.Age).HasColumnType("int(11)");
            entity.Property(e => e.Nom).HasMaxLength(50);
            entity.Property(e => e.Prenom).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
