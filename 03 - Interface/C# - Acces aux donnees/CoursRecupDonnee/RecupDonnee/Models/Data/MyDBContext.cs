using Microsoft.EntityFrameworkCore;

namespace RecupDonnee.Models.Data
{
	public class MyDBContext : DbContext
	{
		public MyDBContext(DbContextOptions options) : base(options)
		{
		}
	}
}
