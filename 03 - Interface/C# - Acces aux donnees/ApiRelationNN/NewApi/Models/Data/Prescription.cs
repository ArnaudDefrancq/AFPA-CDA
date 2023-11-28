using System;
using System.Collections.Generic;

namespace NewApi.Models.Data;

public partial class Prescription
{
	public int IdPrescription { get; set; }

	public int? Soignant { get; set; }

	public int? Medoc { get; set; }

	public int DatePrescription { get; set; }

	public virtual Medicament? ListMedicaments { get; set; }

	public virtual Medecin? ListMedecins { get; set; }
}
