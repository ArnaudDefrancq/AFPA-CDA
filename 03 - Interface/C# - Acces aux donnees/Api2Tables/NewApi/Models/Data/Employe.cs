using System;
using System.Collections.Generic;

namespace NewApi.Models.Data;

public partial class Employe
{
    public int IdEmploye { get; set; }

    public string? Nom { get; set; }

    public string? Prenom { get; set; }

    public int? Age { get; set; }

    public virtual ICollection<Voiturefonction> Voiturefonctions { get; set; } = new List<Voiturefonction>();
}
