using NewApi.Models.Data;

namespace NewApi.Models.Dtos
{
	public class EmployesDto
	{
		public string? Nom { get; set; }

		public string? Prenom { get; set; }

		public int? Age { get; set; }

		public virtual ICollection<VoituresFonctionsDto2> Voiturefonctions { get; set; } = new List<VoituresFonctionsDto2>();

	}

	public class EmployesDtoTest
	{
		public string? Nom { get; set; }

		public string? Prenom { get; set; }

		public int? Age { get; set; }

		//public virtual ICollection<VoituresFonctionsDto> Voiturefonctions { get; set; } = new List<VoituresFonctionsDto>();
	}
}
