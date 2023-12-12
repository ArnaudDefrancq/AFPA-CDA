using System.Collections.Generic;


namespace gestionStock.Models.Dtos
{
	public class CategorieDtoIn
	{
		public string? LibelleCategorie { get; set; }

		public int IdTypeProduit { get; set; }
	}

	public class CategorieDtoSansArticleSansType
	{
		public int IdCategorie { get; set; }

		public string? LibelleCategorie { get; set; }

		public int IdTypeProduit { get; set; }
	}

	public class CategorieDtoAplatie
	{
		public int IdCategorie { get; set; }

		public string? LibelleCategorie { get; set; }

		public int IdTypeProduit { get; set; }

		public List<string> LibelleArticle { get; set; }

		public string LibelleTypeProduit { get; set; }
	}
}
