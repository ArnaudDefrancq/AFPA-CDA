namespace CRUD.Models.Dtos
{
	public class CategorieDtoOut // Pour afficher les categories
	{
		public int IdCategorie { get; set; }

		public string? TypeAppartement { get; set; }

		public virtual ICollection<AppartementDtoIn> Appartements { get; set; } = new List<AppartementDtoIn>();
	}
	public class CategorieDtoIn // Pour mettre en base de donnée une categorie
	{
		public string? TypeAppartement { get; set; }
	}
}
