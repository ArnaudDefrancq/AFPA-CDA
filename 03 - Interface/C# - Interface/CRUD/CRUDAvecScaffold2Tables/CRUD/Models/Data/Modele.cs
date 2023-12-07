using System;
using System.Collections.Generic;

namespace CRUD.Models.Data;

public partial class Modele
{
    public int IdModele { get; set; }

    public string? Libelle { get; set; }

    public int MarqueId { get; set; }

    public virtual Marque Marque { get; set; } = null!;
}
