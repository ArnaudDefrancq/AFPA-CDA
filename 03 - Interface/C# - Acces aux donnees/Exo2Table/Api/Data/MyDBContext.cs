using Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
	public class MyDBContext : DbContext
	{
		public DbSet<Employe> Employes { get; set; }

		public DbSet<Voiturefonction> Voiturefonctions { get; set; }

		public MyDBContext(DbContextOptions options) : base(options)
		{
		}
	}
}
