using Api.Data.Models;

namespace Api.Data.DTO
{
	public class VoitureFonctionDTO
	{
		public string Marque { get; set; } = null!;

		public int Kilometre { get; set; }

		public string Model { get; set; } = null!;

		public virtual ICollection<Employe> Employes { get; set; } = new List<Employe>();
	}
}
