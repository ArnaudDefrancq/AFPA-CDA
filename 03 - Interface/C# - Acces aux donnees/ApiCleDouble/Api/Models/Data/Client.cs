using System;
using System.Collections.Generic;

namespace Api.Models.Data;

public partial class Client
{
    public int IdClient { get; set; }

    public string? Nom { get; set; }

    public string? Prenom { get; set; }

    public virtual ICollection<Acheter> Acheters { get; set; } = new List<Acheter>();
}
