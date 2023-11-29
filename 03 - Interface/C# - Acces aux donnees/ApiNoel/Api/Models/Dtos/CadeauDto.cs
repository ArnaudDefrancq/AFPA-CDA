using Api.Models.Data;

namespace Api.Models.Dtos
{
	public class CadeauDto
	{
		public string? Nom { get; set; }

		public int? Prix { get; set; }

		public virtual ICollection<EnfantDto> Enfants { get; set; } = new List<EnfantDto>();
	}
}
