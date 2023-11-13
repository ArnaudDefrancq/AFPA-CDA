using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Compte
{
	internal class Compte
	{
		// Proporiété
		public int IdCompte { get; private set; }
		public int Solde { get; private set; } = 0;
		public Client Proprietaire { get; set; }
		public static int Compteur { get; set; } = 0;

		// Constructeur
		public Compte(int solde, Client proprietaire)
		{
			IdCompte = ++Compteur;
			Solde = solde;
			Proprietaire = proprietaire;
		}

		// Methode
		// Affichage
		public override string ToString()
		{
			String aff;
			aff = "****************************************" + " \n";
			aff += "Numéro de comtpe : " + IdCompte + " \n";
			aff += "Solde de comtpe : " + Solde + "\n";
			aff += "CIN : " + Proprietaire.Cin + "\n";
			aff += "NOM : " + Proprietaire.Nom + "\n";
			aff += "Prénom : " + Proprietaire.Prenom + "\n";
			aff += "Tél. : " + Proprietaire.Tel + "\n";
			aff += "****************************************" + " \n";

			return aff;
		}

		/// <summary>
		/// Crediter un compte sans débiter d'autre compte
		/// </summary>
		/// <param name="somme"></param>
		/// <returns>int</returns>
		public int Crediter(int somme)
		{
			int credit = Solde + somme;
			return Solde = credit;
		}

		/// <summary>
		/// Crediter un compte avec débit d'autre compte
		/// </summary>
		/// <param name="somme"></param>
		/// <param name="compte"></param>
		/// <returns>bool</returns>
		public bool Crediter(int somme, Compte compteADebiter)
		{
			Solde += this.Crediter(somme);
			compteADebiter.Solde -= this.Debiter(somme);
			return true;

		}

		/// <summary>
		/// Debiter une comtpe
		/// </summary>
		/// <param name="somme"></param>
		/// <returns>int</returns>
		public int Debiter(int somme)
		{
			int debit = Solde - somme;
			return Solde = debit;
		}

		/// <summary>
		/// Debiter le compte et crediter un autre comtpe
		/// </summary>
		/// <param name="somme"></param>
		/// <param name="compte"></param>
		/// <returns></returns>
		public bool Debiter(int somme, Compte compteADebiter)
		{
			Solde = this.Debiter(somme);
			compteADebiter.Solde = this.Crediter(somme);

			return true;
		}

		/// <summary>
		/// Permet de savoir combien de comtpe a été créer
		/// </summary>
		/// <returns>int nb compte</returns>
		public static int NbComtpe()
		{
			return Compteur;
		}
	}
}
