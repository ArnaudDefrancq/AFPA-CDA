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
		private int IdCompte { get; }
		private int Solde { get; set; } = 0;
		public Client Proprietaire { get; set; }
		public static int Compteur { get; set; } = 1;

		// Constructeur
		public Compte(int solde, Client proprietaire)
		{
			IdCompte = Compteur++;
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

		// Crediter un comtpe (sans débit autre comtpe)
		public int CrediterSansDebit(int somme)
		{
			int credit = Solde + somme;
			return Solde = credit;
		}

		// Vérifie si on peut débiter le compte
		private bool CheckCredit(int somme, Compte compte)
		{
			return somme >= compte.Solde ? true : false;

		}

		// Crediter un compte (avec débit autre compte)
		public int CrediterAvecDebit(int somme, Compte compte)
		{


			Solde = Solde + somme;
			compte.Solde = compte.Solde - somme;

			return Solde;

		}

		// Check débit
		private bool CheckDebit(int somme, int solde)
		{
			return somme >= solde ? true : false;

		}
		// Debiter un compte (sans autre compte)
		public int Debiter(int somme)
		{
			int debit = Solde - somme;
			return Solde = debit;
		}

		//Debiter un compte (avec autre comte)
		public int DebiterAvecAutreCompte(int somme, Compte compte)
		{

			Solde = Solde - somme;
			compte.Solde = compte.Solde + somme;

			return Solde;
		}
	}
}
