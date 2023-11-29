using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.CLASS
{
	public class Produits
	{
		public int IdProduit { get; set; }
		public String LibelleProduit { get; set; }
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
	}
}
