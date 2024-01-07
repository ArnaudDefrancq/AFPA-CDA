using System.Collections.Generic;

namespace gestionStock.Models.Dtos
{
	public class TypesProduitDtoIn
	{
		public string? LibelleTypeProduit { get; set; }

		public TypesProduitDtoIn(string? libelleTypeProduit)
		{
			LibelleTypeProduit = libelleTypeProduit;
		}
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

		public List<CategorieDtoSansType> AllCategories { get; set; } = new List<CategorieDtoSansType>();
	}
}
