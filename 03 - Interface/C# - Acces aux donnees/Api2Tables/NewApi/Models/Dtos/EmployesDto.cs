using NewApi.Models.Data;

namespace NewApi.Models.Dtos
{
	public class EmployesDto
	{
		public string Nom { get; set; } = null!;

		public string Prenom { get; set; } = null!;

		public int Age { get; set; }

		public int? IdVoitureFonction { get; set; }

		public virtual Voiturefonction? IdVoitureFonctionNavigation { get; set; }
	}
}
