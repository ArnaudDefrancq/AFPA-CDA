using System.Collections.Generic;

namespace gestionStock.Models.Dtos
{
	public class TypesProduitDtoIn
	{
		public string? LibelleTypeProduit { get; set; }
	}

	public class TypesProduitDtoSansCategorie
	{
		public int IdTypeProduit { get; set; }

		public string? LibelleTypeProduit { get; set; }
	}
	public class TypesProduitDtoAplatie
	{

		public int IdTypeProduit { get; set; }

		public string? LibelleTypeProduit { get; set; }

		public List<CategorieDtoSansArticleSansType> ListCategorie { get; set; }

		public List<ArticleDtoSansCategorie> ListArticle { get; set; }
	}
}
