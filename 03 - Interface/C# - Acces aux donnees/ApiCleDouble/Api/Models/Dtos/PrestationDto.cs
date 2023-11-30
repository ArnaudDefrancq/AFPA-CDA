using Api.Models.Data;

namespace Api.Models.Dtos
{
	public class PrestationDto
	{
		public string? Nom { get; set; }

		public string? Prix { get; set; }

		public virtual ICollection<AcheterDto> Acheters { get; set; } = new List<AcheterDto>();
	}
	public class PrestationDtoNoLoop
	{
		public string? Nom { get; set; }

		public string? Prix { get; set; }
	}
}
