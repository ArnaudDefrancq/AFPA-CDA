using System;
using System.Collections.Generic;

namespace NewApi.Models.Data;

public partial class Voiturefonction
{
    public int IdVoitures { get; set; }

    public string? Marque { get; set; }

    public string? Model { get; set; }

    public int? Km { get; set; }

    public int? IdEmploye { get; set; }

    public virtual Employe? IdEmployeNavigation { get; set; }
}
