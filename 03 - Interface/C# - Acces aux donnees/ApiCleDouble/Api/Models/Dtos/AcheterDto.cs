using Api.Models.Data;

namespace Api.Models.Dtos
{
	public class AcheterDto
	{
		public int DatePresta { get; set; }

		public virtual Client IdClientNavigation { get; set; } = null!;

		public virtual Prestation IdPrestationNavigation { get; set; } = null!;
	}
}
