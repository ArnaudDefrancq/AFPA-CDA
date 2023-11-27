using NewApi.Models.Data;

namespace NewApi.Models.Dtos
{
	public class VoituresFonctionsDto
	{
		public string Marque { get; set; } = null!;

		public int Kilometre { get; set; }

		public string Model { get; set; } = null!;

		public virtual ICollection<Employe> Employes { get; set; } = new List<Employe>();
	}
}
