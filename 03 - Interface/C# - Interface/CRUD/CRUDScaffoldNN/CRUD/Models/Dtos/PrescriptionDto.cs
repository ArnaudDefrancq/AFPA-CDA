namespace CRUD.Models.Dtos
{
	public class PrescriptionDtoOut
	{
		public int IdPrescription { get; set; }

		public int? Soignant { get; set; }

		public int? Medoc { get; set; }

		public int DatePrescription { get; set; }

		public virtual MedicamentDtoSansPrescription? LeMedicament { get; set; }

		public virtual MedecinDtoSansPrescriptions? LeSoignant { get; set; }
	}

	public class PrescriptionDtoOutAplatie
	{
		public int IdPrescription { get; set; }

		public int? Soignant { get; set; }

		public int? Medoc { get; set; }

		public int DatePrescription { get; set; }

		public string NomMedecin { get; set; }

		public string PrenomMedecin { get; set; }

		public int AgeMedecin { get; set; }

		public string NomMedicament { get; set; }

		public string NomEntreprise { get; set; }
	}

	public class PrescriptionDtoIn
	{
		public int? Soignant { get; set; }

		public int? Medoc { get; set; }

		public int DatePrescription { get; set; }
	}
}
