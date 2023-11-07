using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoEmploye
{
	internal class Employe
	{
		// Propriété
		public String Nom { get; set; }
		public String Prenom { get; set; }
		public String DateEmbauche { get; set; }
		public int Salaire { get; set; }
		public String Service { get; set; }

		// Constructeur
		public Employe(string nom, string prenom, String dateEmbauche, int salaire, string service)
		{
			Nom = nom;
			Prenom = prenom;
			DateEmbauche = dateEmbauche;
			Salaire = salaire;
			Service = service;
		}

		// Methode

		// Affichage
		public override string ToString()
		{
			String aff = "Embauché depuis " + JourEnEntreprise() + " jours \n";
			aff += "Et embauché depuis " + AnneeAnciennete() + " années \n";
			aff += "prime total " + CalculPrimeTotal() + "\n";
			return aff;
		}

		// Calcul la différence en jour entre date embauche et date actuelle
		private int JourEnEntreprise()
		{
			DateTime date = DateTime.Now;
			DateTime dateEmb = Convert.ToDateTime(DateEmbauche);
			TimeSpan ts = date.Subtract(dateEmb);
			int diff = ts.Days;

			return diff;
		}

		// Calcule le nb d'année dans l'entreprise
		private int AnneeAnciennete()
		{
			int days = JourEnEntreprise();

			Double annee = Math.Floor(Convert.ToDouble(days) / 365);

			return Convert.ToInt32(annee);
		}

		// Calcul prime sur le salaire annuel
		private int PrimeSalaireAnnuel()
		{
			Double prime;
			Double salaire = Convert.ToDouble(Salaire);
			prime = (salaire * 1000) * 0.05;

			int primeAnnuel = Convert.ToInt32(prime);

			return primeAnnuel;
		}

		// Calcul prime sur l'ancienneté
		private int PrimeAnciennete()
		{
			Double salaire = Convert.ToDouble(Salaire);
			Double prime = (salaire * 1000) * (0.02 * AnneeAnciennete());

			int primeAncien = Convert.ToInt32(prime);

			return primeAncien;
		}

		// Calcul de la prime total
		private int CalculPrimeTotal()
		{
			int primeTotal;
			primeTotal = PrimeAnciennete() + PrimeSalaireAnnuel();

			return primeTotal;
		}
	}
}
