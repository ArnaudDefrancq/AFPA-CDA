namespace CRUD.Models.Dtos
{
	public class AppartementDtoIn //Pour rentrer en BDD
	{
		public int IdAppartement { get; set; }

		public int? Prix { get; set; }

		public string? Adresse { get; set; }

		public int? NumeroAppartement { get; set; }

		public string? Ville { get; set; }

		public int Type { get; set; }

		public AppartementDtoIn(int idAppartementn, int? prix, string? adresse, int? numeroAppartement, string? ville, int type)
		{
			IdAppartement = idAppartementn;
			Prix = prix;
			Adresse = adresse;
			NumeroAppartement = numeroAppartement;
			Ville = ville;
			Type = type;
		}
	}

	public class AppartementDtoSansBoucle // Permet de casser la boucle
	{
		public int? Prix { get; set; }

		public string? Adresse { get; set; }

		public int? NumeroAppartement { get; set; }

		public string? Ville { get; set; }

	}
	public class AppartementDtoApplatieAvecCategorie // Pour afficher le libelle de la categorie sans afficher l'ID categorie
	{
		public int IdAppartement { get; set; }

		public int? Prix { get; set; }

		public string? Adresse { get; set; }

		public int? NumeroAppartement { get; set; }

		public string? Ville { get; set; }

		public int Type { get; set; }

		public string TypeAppartement { get; set; }
	}
}

