using NewApi.Models.Data;

namespace NewApi.Models.Dtos
{
	public class MedicamentDto
	{
		public string NomMedicament { get; set; } = null!;

		public string Entreprise { get; set; } = null!;

		public virtual ICollection<PrescriptionDtoGetMedicament> Prescriptions { get; set; } = new List<PrescriptionDtoGetMedicament>();
	}

	public class MedicamentDtoMedecin
	{
		public string NomMedicament { get; set; } = null!;

		public string Entreprise { get; set; } = null!;
	}
}
