using System;

namespace CRUDGestionCours.Models.Data;

public partial class Inscription
{
	public int IdInscriptions { get; set; }

	public int? Etudiant { get; set; }

	public int? Cours { get; set; }

	public DateTime? DateInscription { get; set; }

	public virtual Cour? LeCours { get; set; }

	public virtual Etudiant? LeEtudiant { get; set; }
}
