namespace gestionStock.Models.Dtos
{
	public class ArticleDtoIn
	{
		public string? LibelleArticle { get; set; }

		public int? QuantiteStrockee { get; set; }

		public int IdCategorie { get; set; }

		public ArticleDtoIn(string? libelleArticle, int? quantiteStrockee, int idCategorie)
		{
			LibelleArticle = libelleArticle;
			QuantiteStrockee = quantiteStrockee;
			IdCategorie = idCategorie;
		}
	}

	public class ArticleDtoSansCategorie
	{
		public int IdArticle { get; set; }

		public string? LibelleArticle { get; set; }

		public int? QuantiteStrockee { get; set; }

		public int IdCategorie { get; set; }
	}
	public class ArticleDtoOutAplatie
	{
		public int IdArticle { get; set; }

		public string? LibelleArticle { get; set; }

		public int? QuantiteStrockee { get; set; }

		public int IdCategorie { get; set; }

		public string LibelleCategorie { get; set; }

		public string LibelleTypeProduit { get; set; }
	}

}
