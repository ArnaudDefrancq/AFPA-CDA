using NewApi.Models.Data;

namespace NewApi.Models.Dtos
{
	public class PrescriptionDto
	{
		public int DatePrescription { get; set; }

		public virtual MedicamentDtoOutPrescription? ListMedicaments { get; set; }

		public virtual MedecinDtoPost? ListeMedecins { get; set; }
	}

	public class PrescriptionDtoOutSoignant
	{
		public int DatePrescription { get; set; }

		public virtual MedicamentDtoOutPrescription? ListMedicaments { get; set; }

	}

	public class PrescriptionDtoOutSoignantOutMedoc
	{
		public int DatePrescription { get; set; }

		public virtual MedecinDtoPost? ListMedecins { get; set; }
	}

	public class PrescriptionDtoPost
	{
		public int? Soignant { get; set; }

		public int? Medoc { get; set; }

		public int DatePrescription { get; set; }
	}
}