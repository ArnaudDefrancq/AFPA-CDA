using System;
using System.Collections.Generic;

namespace RecupDonnee.Models.Data;

public partial class Personne
{
    public uint Id { get; set; }

    public string? Nom { get; set; }

    public string? Prenom { get; set; }

    public int? CodePostal { get; set; }

    public string Adresse { get; set; } = null!;

    public string Ville { get; set; } = null!;
}
