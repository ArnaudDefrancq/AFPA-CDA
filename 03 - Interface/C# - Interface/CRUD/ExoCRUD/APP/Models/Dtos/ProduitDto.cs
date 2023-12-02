namespace APP.Models.Dtos
{
	public class ProduitDto
	{
		public string LibelleProduit { get; set; }
		public int Quantite { get; set; }
		public int PrixUnitaire { get; set; }
		public int Date { get; set; }

		public ProduitDto(string libelleProduit, int quantite, int prixUnitaire, int date)
		{
			LibelleProduit = libelleProduit;
			Quantite = quantite;
			PrixUnitaire = prixUnitaire;
			Date = date;
		}
	}
}
