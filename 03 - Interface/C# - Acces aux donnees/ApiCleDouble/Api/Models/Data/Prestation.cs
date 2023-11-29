using System;
using System.Collections.Generic;

namespace Api.Models.Data;

public partial class Prestation
{
    public int IdPrestation { get; set; }

    public string? Nom { get; set; }

    public string? Prix { get; set; }

    public virtual ICollection<Acheter> Acheters { get; set; } = new List<Acheter>();
}
