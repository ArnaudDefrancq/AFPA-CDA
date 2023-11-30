using Api.Models.Data;

namespace Api.Models.Dtos
{
	public class ClientDto
	{
		public string? Nom { get; set; }

		public string? Prenom { get; set; }

		public virtual ICollection<AcheterDto> Acheters { get; set; } = new List<AcheterDto>();
	}
	public class ClientDtoNoLoop
	{
		public string? Nom { get; set; }

		public string? Prenom { get; set; }
	}
}
