using System;
using System.Collections.Generic;

namespace CRUD.Models.Data;

public partial class Appartement
{
    public int IdAppartement { get; set; }

    public int? Prix { get; set; }

    public string? Adresse { get; set; }

    public int? NumeroAppartement { get; set; }

    public string? Ville { get; set; }

    public int Type { get; set; }

    public virtual Categorie CategorieAppartement { get; set; } = null!;
}
