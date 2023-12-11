namespace CRUD.Models.Dtos
{
	public class CategorieDtoOutAvecAppartement // Pour afficher les categories
	{
		public int IdCategorie { get; set; }

		public string? TypeAppartement { get; set; }

		public virtual ICollection<AppartementDtoSansBoucle> Appartements { get; set; } = new List<AppartementDtoSansBoucle>();
	}

	public class CategorieDtoOutSansAppartement
	{
		public int IdCategorie { get; set; }

		public string? TypeAppartement { get; set; }
	}

	public class CategorieDtoIn // Pour mettre en base de donnée une categorie
	{
		public string? TypeAppartement { get; set; }
	}
}
