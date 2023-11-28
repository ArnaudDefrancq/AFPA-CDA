using System;
using System.Collections.Generic;

namespace NewApi.Models.Data;

public partial class Medicament
{
    public int IdMedicament { get; set; }

    public string NomMedicament { get; set; } = null!;

    public string Entreprise { get; set; } = null!;

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
