using System;
using System.Collections.Generic;

namespace NewApi.Models.Data;

public partial class Employe
{
    public int IdEmploye { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public int Age { get; set; }

    public int? IdVoitureFonction { get; set; }

    public virtual Voiturefonction? IdVoitureFonctionNavigation { get; set; }
}
