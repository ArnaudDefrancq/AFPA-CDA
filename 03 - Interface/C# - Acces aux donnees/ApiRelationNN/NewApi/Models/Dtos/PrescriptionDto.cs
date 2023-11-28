using NewApi.Models.Data;

namespace NewApi.Models.Dtos
{
	public class PrescriptionDto
	{
		public int? Soignant { get; set; }

		public int? Medoc { get; set; }

		public int DatePrescription { get; set; }

		public virtual Medicament? MedocNavigation { get; set; }

		public virtual Medecin? SoignantNavigation { get; set; }
	}
}
