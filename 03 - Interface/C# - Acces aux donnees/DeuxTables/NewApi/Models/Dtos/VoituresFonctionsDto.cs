using NewApi.Models.Data;

namespace NewApi.Models.Dtos
{
	public class VoituresFonctionsDto
	{
		public string? Marque { get; set; }

		public string? Model { get; set; }

		public int? Km { get; set; }

		public int? IdEmploye { get; set; }

		public virtual Employe? IdEmployeNavigation { get; set; }
	}
	public class VoituresFonctionsDtoTest
	{
		public string? Marque { get; set; }

		public string? Model { get; set; }

		public int? Km { get; set; }

		public int? IdEmploye { get; set; }

		public virtual EmployesDtoTest? IdEmployeNavigation { get; set; }
	}

	public class VoituresFonctionsDto2
	{
		public string? Marque { get; set; }

		public string? Model { get; set; }

		public int? Km { get; set; }

	}
}
