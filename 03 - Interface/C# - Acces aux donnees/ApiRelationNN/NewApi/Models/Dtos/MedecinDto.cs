using NewApi.Models.Data;

namespace NewApi.Models.Dtos
{
	public class MedecinDto
	{
		public string Nom { get; set; } = null!;

		public string Prenom { get; set; } = null!;

		public int? Age { get; set; }

		public virtual ICollection<PrescriptionDtoOutSoignant> Prescriptions { get; set; } = new List<PrescriptionDtoOutSoignant>();
	}
	public class MedecinDtoPost

	{
		public int IdMedecin { get; set; }

		public string Nom { get; set; } = null!;

		public string Prenom { get; set; } = null!;

		public int? Age { get; set; }
	}

	public class MedecinDtoAplatie
	{
		public string Nom { get; set; } = null!;

		public string Prenom { get; set; } = null!;

		public int? Age { get; set; }

		public List<int> DatePrescription {  get; set; }

		public List<string> NomMedicament {  get; set; }

	}

}
