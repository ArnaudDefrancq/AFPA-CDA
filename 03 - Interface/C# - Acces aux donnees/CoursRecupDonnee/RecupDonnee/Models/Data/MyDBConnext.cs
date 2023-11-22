using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;

namespace RecupDonnee.Models.Data
{
	public class MyDBConnext : DbContext
	{
		public MyDBConnext(DbContextOptions<MyDBConnext> options) : base(options)
		{
		}
	}
}
