using Api.Data.Models;

namespace Api.Data.DTO
{
	public class EmployeDTO
	{
		public int IdEmploye { get; set; }

		public string Nom { get; set; } = null!;

		public string Prenom { get; set; } = null!;

		public int Age { get; set; }

		public int? IdVoitureFonction { get; set; }

		public virtual Voiturefonction? IdVoitureFonctionNavigation { get; set; }
	}
}
