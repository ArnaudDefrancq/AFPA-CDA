namespace CRUD.Models.Dtos
{
	public class AppartementDtoIn //Pour rentrer en BDD
	{
		public int? Prix { get; set; }

		public string? Adresse { get; set; }

		public int? NumeroAppartement { get; set; }

		public string? Ville { get; set; }

		public int Type { get; set; }
	}

	//public class AppartementDtoOut // Pour sortir de la BDD et afficher
	//{
	//	public int? Prix { get; set; }

	//	public string? Adresse { get; set; }

	//	public int? NumeroAppartement { get; set; }

	//	public string? Ville { get; set; }

	//	public int Type { get; set; }

	//	public virtual Categorie CategorieAppartement { get; set; } = null!;
	//}
	public class AppartementDtoApplatieAvecCategorie // Pour afficher le libelle de la categorie sans afficher l'ID categorie
	{
		public int IdAppartement { get; set; }

		public int? Prix { get; set; }

		public string? Adresse { get; set; }

		public int? NumeroAppartement { get; set; }

		public string? Ville { get; set; }

		public int Type { get; set; }

		public string CategorieAppartement { get; set; } = null!;
	}
}

