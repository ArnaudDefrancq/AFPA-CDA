using System;
using System.Collections.Generic;

namespace Api.Models.Data;

public partial class Cadeau
{
    public int IdCadeau { get; set; }

    public string? Nom { get; set; }

    public int? Prix { get; set; }

    public virtual ICollection<Enfant> Enfants { get; set; } = new List<Enfant>();
}
