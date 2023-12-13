using System;
using System.Collections.Generic;

namespace WpfApp1.Models.Data;

public partial class Article
{
	public int IdArticle { get; set; }

	public string? LibelleArticle { get; set; }

	public int? QuantiteStrockee { get; set; }

	public int IdCategorie { get; set; }

	public virtual Category LaCategorie { get; set; } = null!;
}
