using NewApi.Models.Data;

namespace NewApi.Models.Dtos
{
	public class EmployesDto
	{
		public string? Nom { get; set; }

		public string? Prenom { get; set; }

		public int? Age { get; set; }

		public virtual ICollection<Voiturefonction> Voiturefonctions { get; set; } = new List<Voiturefonction>();
	}
}
