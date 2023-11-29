using Api.Models.Data;

namespace Api.Models.Dtos
{
	public class PrestationDto
	{
		public string? Nom { get; set; }

		public string? Prix { get; set; }

		public virtual ICollection<Acheter> Acheters { get; set; } = new List<Acheter>();
	}
}
