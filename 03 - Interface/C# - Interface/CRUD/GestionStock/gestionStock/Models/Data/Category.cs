using System;
using System.Collections.Generic;

namespace WpfApp1.Models.Data;

public partial class Category
{
	public int IdCategorie { get; set; }

	public string? LibelleCategorie { get; set; }

	public int IdTypeProduit { get; set; }

	public virtual ICollection<Article> LesArticles { get; set; } = new List<Article>();

	public virtual Typesproduit LeTypeProduit { get; set; } = null!;
}
