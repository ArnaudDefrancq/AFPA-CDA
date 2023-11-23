using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace ModelToDb.Models.Data
{
	public class Personnes
	{
		public int Id { get; set; }

		[MaxLength(50)]
		public String Prenom { get; set; }

		[MaxLength(50)]
		public String Nom { get; set; }


		public int Age { get; set; }

		public DateOnly Naissance { get; set; }
	}
}
