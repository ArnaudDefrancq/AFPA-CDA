using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoPoo.Class
{
	public class Vendeurs : Commerciaux
	{
		const Double NB_IRIS_PAR_PRIME = 2;
		const Double SALAIRE_DE_BASE = 50;


		// Propriete

		// Constructeur
		public Vendeurs(int age, string nom, string prenom, double nbDeplacement, double nbPrime) : base(age, nom, prenom, nbDeplacement, nbPrime)
		{
			Salaire = CalculSalaire();
		}

		// Methode
		// Affiche
		public override string ToString()
		{
			String aff = "";
			aff += "Nom : " + Nom + " - Prenom : " + Prenom + " - Age : " + Age + " - Salaire : " + Salaire;
			aff += " Dont Salaire de " + SALAIRE_DE_BASE + " + " + base.NbPrime + " primes à " + NB_IRIS_PAR_PRIME;

			return aff;
		}

		/// <summary>
		/// Calcule le salaire avec les primes
		/// </summary>
		/// <returns></returns>
		public override Double CalculSalaire()
		{
			Double sal;
			sal = NB_IRIS_PAR_PRIME * base.NbPrime + SALAIRE_DE_BASE;

			return sal;
		}
	}
}
