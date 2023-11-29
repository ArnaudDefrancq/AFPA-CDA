using System;
using System.Collections.Generic;

namespace Api.Models.Data;

public partial class Acheter
{
    public int IdPrestation { get; set; }

    public int IdClient { get; set; }

    public int DatePresta { get; set; }

    public virtual Client ListClients { get; set; } = null!;

    public virtual Prestation ListPrestations { get; set; } = null!;
}
