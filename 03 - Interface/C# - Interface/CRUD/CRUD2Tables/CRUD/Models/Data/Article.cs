namespace CRUD.Models.Data
{
	public class Article
	{
		public int IdArticle { get; set; }
		public string LibelleArticle { get; set; }
		public int Quantite { get; set; }
		public int PrixUnitaire { get; set; }
		public int MontantTotal { get; set; }
		public int IdCategorie { get; set; }
		public static int Compteur { get; set; } = 0;

		public Article(string libelleArticle, int quantite, int prixUnitaire, int idCategorie)
		{
			IdArticle = ++Compteur;
			LibelleArticle = libelleArticle;
			Quantite = quantite;
			PrixUnitaire = prixUnitaire;
			MontantTotal = PrixUnitaire * Quantite;
			IdCategorie = idCategorie;
		}

		public Article(int idArticle, string libelleArticle, int quantite, int prixUnitaire, int montantTotal, int idCategorie)
		{
			IdArticle = idArticle;
			LibelleArticle = libelleArticle;
			Quantite = quantite;
			PrixUnitaire = prixUnitaire;
			MontantTotal = montantTotal;
			IdCategorie = idCategorie;
		}
	}
}
