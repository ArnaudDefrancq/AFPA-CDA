namespace APP.Models.Data
{
	public class Produits
	{
		public int IdProduit { get; set; }
		public string LibelleProduit { get; set; }
		public int Quantite { get; set; }
		public int PrixUnitaire { get; set; }
		public int Date { get; set; }
		public static int Compteur { get; set; } = 0;

		public Produits(string libelleProduit, int quantite, int prixUnitaire, int date)
		{
			IdProduit = ++Compteur;
			LibelleProduit = libelleProduit;
			Quantite = quantite;
			PrixUnitaire = prixUnitaire;
			Date = date;
		}

		public Produits()
		{
		}

		public Produits(int idProduit, string libelleProduit, int quantite, int prixUnitaire, int date)
		{
			IdProduit = idProduit;
			LibelleProduit = libelleProduit;
			Quantite = quantite;
			PrixUnitaire = prixUnitaire;
			Date = date;
		}
	}
}
