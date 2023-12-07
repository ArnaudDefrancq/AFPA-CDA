using System;
using System.Collections.Generic;

namespace CRUD.Models.Data;

public partial class Marque
{
    public int IdMarque { get; set; }

    public string Libelle { get; set; } = null!;

    public virtual ICollection<Modele> Modeles { get; set; } = new List<Modele>();
}
