using NewApi.Models.Data;

namespace NewApi.Models.Dtos
{
	public class MedicamentDto
	{
		public string NomMedicament { get; set; } = null!;

		public string Entreprise { get; set; } = null!;

		public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
	}
}
