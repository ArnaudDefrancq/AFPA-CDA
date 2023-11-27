using Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
	public class MyDBContext : DbContext
	{
		public DbSet<Employe> Employe { get; set; }

		public DbSet<Voiturefonction> Voiturefonction { get; set; }

		public MyDBContext(DbContextOptions options) : base(options)
		{
		}
	}
}
