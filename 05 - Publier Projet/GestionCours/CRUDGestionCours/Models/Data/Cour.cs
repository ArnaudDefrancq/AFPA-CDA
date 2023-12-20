using System.Collections.Generic;

namespace CRUDGestionCours.Models.Data;

public partial class Cour
{
	public int IdCours { get; set; }

	public string? Nom { get; set; }

	public string? Description { get; set; }

	public virtual ICollection<Inscription> Inscriptions { get; set; } = new List<Inscription>();
}
