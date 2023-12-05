namespace CRUD.Models.Dtos
{
	public class ArticleDto
	{
		public int IdArticle { get; set; }
		public string LibelleArticle { get; set; }
		public int Quantite { get; set; }
		public int PrixUnitaire { get; set; }
		public int MontantTotal { get; set; }
		public string LibelleCategorie { get; set; }

		public ArticleDto(int idArticle, string libelleArticle, int quantite, int prixUnitaire, int montantTotal, string libelleCategorie)
		{
			IdArticle = idArticle;
			LibelleArticle = libelleArticle;
			Quantite = quantite;
			PrixUnitaire = prixUnitaire;
			MontantTotal = montantTotal;
			LibelleCategorie = libelleCategorie;
		}
	}
}
