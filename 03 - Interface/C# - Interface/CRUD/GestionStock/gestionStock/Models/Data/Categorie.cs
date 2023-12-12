using System.Collections.Generic;

namespace gestionStock.Models.Data;

public partial class Categorie
{
	public int IdCategorie { get; set; }

	public string? LibelleCategorie { get; set; }

	public int IdTypeProduit { get; set; }

	public virtual ICollection<Article> LesArticles { get; set; } = new List<Article>();

	public virtual TypesProduit LeTypeProduit { get; set; } = null!;
}
