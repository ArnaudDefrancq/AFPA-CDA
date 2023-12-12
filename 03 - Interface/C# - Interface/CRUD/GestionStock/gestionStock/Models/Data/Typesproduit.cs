using System;
using System.Collections.Generic;

namespace gestionStock.Models.Data;

public partial class Typesproduit
{
	public int IdTypeProduit { get; set; }

	public string? LibelleTypeProduit { get; set; }

	public virtual ICollection<Categorie> LesCategories { get; set; } = new List<Categorie>();
}
