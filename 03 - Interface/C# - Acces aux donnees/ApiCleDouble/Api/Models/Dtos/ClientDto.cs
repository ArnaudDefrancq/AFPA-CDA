using Api.Models.Data;

namespace Api.Models.Dtos
{
	public class ClientDto
	{
		public string? Nom { get; set; }

		public string? Prenom { get; set; }

		public virtual ICollection<Acheter> Acheters { get; set; } = new List<Acheter>()
	}
}
