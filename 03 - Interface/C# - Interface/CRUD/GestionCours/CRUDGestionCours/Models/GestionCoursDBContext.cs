using System.Configuration;
using CRUDGestionCours.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace CRUDGestionCours.Models;

public partial class GestionCoursDBContext : DbContext
{
	public GestionCoursDBContext()
	{
	}

	public GestionCoursDBContext(DbContextOptions<GestionCoursDBContext> options)
		: base(options)
	{
	}

	public virtual DbSet<Cour> Cours { get; set; }

	public virtual DbSet<Etudiant> Etudiants { get; set; }

	public virtual DbSet<Inscription> Inscriptions { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseMySQL(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Cour>(entity =>
		{
			entity.HasKey(e => e.IdCours).HasName("PRIMARY");

			entity.ToTable("cours");

			entity.Property(e => e.IdCours).HasColumnType("int(11)");
			entity.Property(e => e.Description).HasMaxLength(255);
			entity.Property(e => e.Nom).HasMaxLength(50);
		});

		modelBuilder.Entity<Etudiant>(entity =>
		{
			entity.HasKey(e => e.IdEtudiants).HasName("PRIMARY");

			entity.ToTable("etudiants");

			entity.Property(e => e.IdEtudiants).HasColumnType("int(11)");
			entity.Property(e => e.Age).HasColumnType("int(11)");
			entity.Property(e => e.Nom).HasMaxLength(50);
			entity.Property(e => e.Prenom).HasMaxLength(50);
		});

		modelBuilder.Entity<Inscription>(entity =>
		{
			entity.HasKey(e => e.IdInscriptions).HasName("PRIMARY");

			entity.ToTable("inscriptions");

			entity.HasIndex(e => e.Etudiant, "inscriptions_ibfk_1");

			entity.HasIndex(e => e.Cours, "inscriptions_ibfk_2");

			entity.Property(e => e.IdInscriptions).HasColumnType("int(11)");
			entity.Property(e => e.Cours).HasColumnType("int(11)");
			entity.Property(e => e.DateInscription).HasColumnType("datetime");
			entity.Property(e => e.Etudiant).HasColumnType("int(11)");

			entity.HasOne(d => d.LeCours).WithMany(p => p.Inscriptions)
				.HasForeignKey(d => d.Cours)
				.OnDelete(DeleteBehavior.Cascade)
				.HasConstraintName("inscriptions_ibfk_2");

			entity.HasOne(d => d.LeEtudiant).WithMany(p => p.Inscriptions)
				.HasForeignKey(d => d.Etudiant)
				.OnDelete(DeleteBehavior.Cascade)
				.HasConstraintName("inscriptions_ibfk_1");
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
