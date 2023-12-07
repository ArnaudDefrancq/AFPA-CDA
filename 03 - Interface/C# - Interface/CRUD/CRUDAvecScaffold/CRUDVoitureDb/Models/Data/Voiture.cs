using System;
using System.Collections.Generic;

namespace CRUDVoitureDb.Models.Data;

public partial class Voiture
{
	public int IdVoiture { get; set; }

	public string? Marque { get; set; }

	public string? Model { get; set; }

	public int? Km { get; set; }

}
