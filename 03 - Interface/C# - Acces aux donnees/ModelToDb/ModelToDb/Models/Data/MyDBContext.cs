using Microsoft.EntityFrameworkCore;
namespace ModelToDb.Models.Data
{
	public class MyDBContext : DbContext
	{
		public DbSet<Personnes> Personnes { get; set; }

		public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Personnes>(e => e.Property(o => o.Id).HasColumnName("IdPersonne"));

		}
	}
}
