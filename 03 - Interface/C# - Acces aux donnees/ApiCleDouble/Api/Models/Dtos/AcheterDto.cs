using Api.Models.Data;

namespace Api.Models.Dtos
{
	public class AcheterDto
	{
		public int DatePresta { get; set; }

		public virtual ClientDtoNoLoop ListClients { get; set; } = null!;

		public virtual PrestationDtoNoLoop ListPrestations { get; set; } = null!;
	}
}