﻿namespace CRUDOpt.Models.Data
{
	public class Article
	{
		public int IdArticle { get; set; }
		public string LibelleArticle { get; set; }
		public int NumeroArticle { get; set; }
		public int Quantite { get; set; }
		public int PrixUnitaire { get; set; }
		public int IdCategorie { get; set; }

		public Article()
		{
		}

		public Article(int idArticle, string libelleArticle, int numeroArtcile, int quantite, int prixUnitaire, int idCategorie)
		{
			IdArticle = idArticle;
			LibelleArticle = libelleArticle;
			NumeroArticle = numeroArtcile;
			Quantite = quantite;
			PrixUnitaire = prixUnitaire;
			IdCategorie = idCategorie;
		}
	}
}
