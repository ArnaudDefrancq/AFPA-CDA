using System;
using System.Collections.Generic;

namespace CRUD.Models.Data;

public partial class Prescription
{
	public int IdPrescription { get; set; }

	public int? Soignant { get; set; }

	public int? Medoc { get; set; }

	public DateTime DatePrescription { get; set; }

	public virtual Medicament? LeMedicament { get; set; }

	public virtual Medecin? LeSoignant { get; set; }
}
