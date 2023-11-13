using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExoEmploye.Program;

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
		public List<Enfant> Enfant { get; set; } = new List<Enfant>();

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
			aff += "Enfant \n";
			if (Enfant.Count() > 0)
			{
				foreach (Enfant enf in Enfant)
				{
					aff += enf.ToString() + "\n";
				}
			}
			aff += "******************** \n";
			aff += "Cheque Noel \n";
			aff += ChequeNoel2();


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

		// Ajout un enfant a l'employe
		public void AjouterEnfant(Enfant enf)
		{
			Enfant.Add(enf);
		}

		// Distribution des cheques noel
		//private String ChequeNoel()
		//{
		//	List<int> cheque = new List<int>() { };
		//	String rep = "";

		//	foreach (Enfant age in Enfant)
		//	{
		//		if (age.Age < 10)
		//		{
		//			cheque.Add(20);
		//		}
		//		else if (age.Age < 15)
		//		{
		//			cheque.Add(30);

		//		}
		//		else if (age.Age < 18)
		//		{
		//			cheque.Add(50);
		//		}
		//		else
		//		{
		//			cheque.Add(0);
		//		}
		//	}

		//	int c50 = 0;
		//	int c30 = 0;
		//	int c20 = 0;

		//	if (cheque.Count() > 0)
		//	{
		//		foreach (int i in cheque)
		//		{
		//			if (i == 50) c50++;
		//			if (i == 30) c30++;
		//			if (i == 20) c20++;
		//		}
		//		rep += c50 + " cheque de 50 euro \n";
		//		rep += c30 + " cheque de 30 euro \n";
		//		rep += c20 + " cheque de 20 euro \n";
		//	}
		//	else
		//	{
		//		rep += "Pas de cheque \n";
		//	}
		//	return rep;
		//}

		// Autre manière d'attribuer des chèques noel
		private String ChequeNoel2()
		{
			int[] tab = new int[3] { 0, 0, 0 };
			String resp = "";

			foreach (var enfant in Enfant)
			{
				tab[(int)enfant.ChequeNoel2()]++;
			}

			if (tab.Sum() == 0) return "Pas de froit aux chèques Noel";

			for (int i = 0; i < tab.Length; i++)
			{
				if (tab[i] > 0) resp += tab[i] + " chèque de " + (Enum.GetName(typeof(valeurNoel), i)).Substring(1) + "\n";
			}

			return resp;
		}
	}
}
