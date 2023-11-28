using System;
using System.Collections.Generic;

namespace NewApi.Models.Data;

public partial class Medecin
{
    public int IdMedecin { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public int? Age { get; set; }

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
