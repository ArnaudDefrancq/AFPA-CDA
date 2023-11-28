using NewApi.Models.Data;

namespace NewApi.Models.Dtos
{
	public class PrescriptionDto
	{
		public int DatePrescription { get; set; }

		public virtual MedicamentDtoMedecin? MedocNavigation { get; set; }

		public virtual MedecinDtoPost? SoignantNavigation { get; set; }
	}

	public class PrescriptionDtoGetMedecin
	{
		public int? Medoc { get; set; }

		public int DatePrescription { get; set; }

	}

	public class PrescriptionDtoGetMedicament
	{
		public int? Soignant { get; set; }

		public int DatePrescription { get; set; }
	}

	public class PrescriptionDtoPost
	{
		public int? Soignant { get; set; }

		public int? Medoc { get; set; }

		public int DatePrescription { get; set; }
	}
}