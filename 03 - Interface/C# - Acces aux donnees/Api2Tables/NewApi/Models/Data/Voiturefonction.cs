using System;
using System.Collections.Generic;

namespace NewApi.Models.Data;

public partial class Voiturefonction
{
    public int IdVoitureFonction { get; set; }

    public string Marque { get; set; } = null!;

    public int Kilometre { get; set; }

    public string Model { get; set; } = null!;

    public virtual ICollection<Employe> Employes { get; set; } = new List<Employe>();
}
