using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Models.Data
{
	public class Article
	{
		public int IdProduit { get; set; }
		public string LibelleProduit { get; set; }
		public int Quantite { get; set; }
		public int PrixUnitaire { get; set; }
		public int MontantTotal { get; set; }
		public string Categorie { get; set; }
		public static int Compteur { get; set; } = 0;

		public Article(string libelleProduit, int quantite, int prixUnitaire, string categorie)
		{
			IdProduit = ++Compteur;
			LibelleProduit = libelleProduit;
			Quantite = quantite;
			PrixUnitaire = prixUnitaire;
			MontantTotal = PrixUnitaire * Quantite;
			Categorie = categorie;
		}

		public Article()
		{
		}
	}
}
