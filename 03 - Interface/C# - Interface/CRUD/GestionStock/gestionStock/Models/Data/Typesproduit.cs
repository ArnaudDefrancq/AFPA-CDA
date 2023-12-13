using System;
using System.Collections.Generic;

namespace WpfApp1.Models.Data;

public partial class Typesproduit
{
	public int IdTypeProduit { get; set; }

	public string? LibelleTypeProduit { get; set; }

	public virtual ICollection<Category> LesCategories { get; set; } = new List<Category>();
}
