namespace CRUDOpt.Models.Dtos
{
	public class ArticleDto
	{
		public int IdArticle { get; set; }
		public string LibelleArticle { get; set; }
		public int NumeroArticle { get; set; }
		public int Quantite { get; set; }
		public int PrixUnitaire { get; set; }
		public string LibelleCategorie { get; set; }

		public ArticleDto()
		{
		}

		public ArticleDto(int idArticle, string libelleArticle, int numeroArtcile, int quantite, int prixUnitaire, string libelleCategorie)
		{
			IdArticle = idArticle;
			LibelleArticle = libelleArticle;
			NumeroArticle = numeroArtcile;
			Quantite = quantite;
			PrixUnitaire = prixUnitaire;
			LibelleCategorie = libelleCategorie;
		}
	}
}
