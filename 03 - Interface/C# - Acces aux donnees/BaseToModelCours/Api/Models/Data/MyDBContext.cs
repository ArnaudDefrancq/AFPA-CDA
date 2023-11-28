using Microsoft.EntityFrameworkCore;

namespace Api.Models.Data
{
	public class MyDBContext : DbContext
	{
		public DbSet<Personne> Personnes { get; set; }

		public MyDBContext(DbContextOptions options) : base(options)
		{
		}
	}
}
