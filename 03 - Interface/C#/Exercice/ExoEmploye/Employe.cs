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
		public Agence Agence { get; set; }
		public List<Enfant> Enfant { get; set; }

		// Constructeur
		public Employe(string nom, string prenom, string dateEmbauche, int salaire, string service, Agence agence, List<Enfant> enfants)
		{
			Nom = nom;
			Prenom = prenom;
			DateEmbauche = dateEmbauche;
			Salaire = salaire;
			Service = service;
			Agence = agence;
			Enfant = enfants;
		}

		// Methode
		// Affichage
		public override string ToString()
		{
			String aff = "******************** \n";
			aff += "Employe \n";
			aff += "Nom :" + Nom + "\n";
			aff += "Prenom : " + Prenom + "\n";
			aff += "Service : " + Service + "\n";
			aff += "Embauché depuis " + JourEnEntreprise() + " jours \n";
			aff += "Et embauché depuis " + AnneeAnciennete() + " années \n";
			aff += "prime total " + CalculPrimeTotal() + "\n";
			aff += "******************** \n";
			aff += "Agence \n";
			aff += "******************** \n";
			aff += Agence.ToString();
			aff += "******************** \n";
			aff += ChequeVacances() ? "Peut avoir des cheques \n" : "Ne peut pas avoir de cheque \n";
			aff += "******************** \n";
			aff += "Enfant";
			aff += "******************** \n";
			if (Enfant.Count() > 0)
			{
				foreach (Enfant e in Enfant)
				{
					aff += e.ToString();
				}
			}
			else
			{
				aff += "pas de cheque \n";
			}
			aff += "******************** \n";
			aff += "Cheque Noel \n";
			List<int> cheque = new List<int>();
			int c50 = 0;
			int c30 = 0;
			int c20 = 0;
			cheque = ChequeNoel();

			if (cheque.Count() > 0)
			{
				foreach (int i in cheque)
				{
					if (i == 50) c50++;
					if (i == 30) c30++;
					if (i == 20) c20++;
				}
				aff += c50 + " cheque de 50 euro \n";
				aff += c30 + " cheque de 30 euro \n";
				aff += c20 + " cheque de 20 euro \n";
			}
			else
			{
				aff += "Pas de cheque \n";
			}

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

		// Calcul de la masse salariale
		public int MasseSalarial()
		{
			int totalSalarial;
			totalSalarial = Salaire + CalculPrimeTotal();

			return totalSalarial;
		}

		// Distribution des cheques vacances
		private bool ChequeVacances()
		{
			return (AnneeAnciennete() >= 1) ? true : false;
		}

		// Distribution des cheques noels
		private List<int> ChequeNoel()
		{
			List<int> cheque = new List<int>();

			foreach (Enfant age in Enfant)
			{
				if (age.Age < 10)
				{
					cheque.Add(20);
				}
				else if (age.Age < 15)
				{
					cheque.Add(30);

				}
				else if (age.Age < 18)
				{
					cheque.Add(50);
				}
				else
				{
					cheque.Add(0);
				}
			}
			return cheque;
		}
	}
}
