using System;
using System.Collections.Generic;

namespace CRUD.Models.Data;

public partial class Categorie
{
    public int IdCategorie { get; set; }

    public string? TypeAppartement { get; set; }

    public virtual ICollection<Appartement> Appartements { get; set; } = new List<Appartement>();
}
