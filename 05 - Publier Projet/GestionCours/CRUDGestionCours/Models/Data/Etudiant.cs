using System.Collections.Generic;

namespace CRUDGestionCours.Models.Data;

public partial class Etudiant
{
	public int IdEtudiants { get; set; }

	public string? Nom { get; set; }

	public string? Prenom { get; set; }

	public int? Age { get; set; }

	public virtual ICollection<Inscription> Inscriptions { get; set; } = new List<Inscription>();
}
