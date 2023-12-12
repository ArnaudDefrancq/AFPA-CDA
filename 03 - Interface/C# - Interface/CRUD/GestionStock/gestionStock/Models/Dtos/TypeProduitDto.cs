using System.Collections.Generic;

namespace gestionStock.Models.Dtos
{
	public class TypeProduitDtoIn
	{
		public string? LibelleTypeProduit { get; set; }
	}

	public class TypeProduitDtoSansCategorie
	{
		public int IdTypeProduit { get; set; }

		public string? LibelleTypeProduit { get; set; }
	}
	public class TypeProduitDtoAplatie
	{

		public int IdTypeProduit { get; set; }

		public string? LibelleTypeProduit { get; set; }

		public List<string> LibelleCategorie { get; set; }

		public List<string> LibelleArticle { get; set; }
	}
}
