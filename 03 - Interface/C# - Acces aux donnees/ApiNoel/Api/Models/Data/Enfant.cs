using System;
using System.Collections.Generic;

namespace Api.Models.Data;

public partial class Enfant
{
	public int IdEnfant { get; set; }

	public string? Nom { get; set; }

	public string? Prenom { get; set; }

	public int? Age { get; set; }

	public int? IdCadeau { get; set; }

	public virtual Cadeau? LeCadeau { get; set; }
}
