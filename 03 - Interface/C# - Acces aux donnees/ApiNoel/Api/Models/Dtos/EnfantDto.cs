using Api.Models.Data;

namespace Api.Models.Dtos
{
	public class EnfantDto
	{
		public string? Nom { get; set; }

		public string? Prenom { get; set; }

		public int? Age { get; set; }

		public int? IdCadeau { get; set; }

		public virtual CadeauDto? LeCadeau { get; set; }
	}
}
