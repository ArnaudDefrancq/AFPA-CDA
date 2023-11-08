using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoPoo.Class
{
	internal class Representants : Commerciaux
	{
		const Double NB_IRIS_PAR_DEPLACEMENT = 1;
		const Double NB_IRIS_PAR_PRIME = 5;
		const Double SALAIRE_DE_BASE = 50;

		// Constructeur
		public Representants(int age, string nom, string prenom, double nbDeplacement, double nbPrime) : base(age, nom, prenom, nbDeplacement, nbPrime)
		{
			Salaire = CalculSalaire();
		}

		// Methode
		// Affichage
		public override string ToString()
		{
			String aff = "Salaries.Représentant ";
			aff += "Nom : " + Nom + " - Prenom : " + Prenom + " - Age : " + Age + " - Salaire : " + Salaire;
			aff += " Dont Salaire de " + SALAIRE_DE_BASE + " + " + base.NbPrime + " primes à " + NB_IRIS_PAR_PRIME + " + " + base.NbDeplacement + " deplacement à " + NB_IRIS_PAR_DEPLACEMENT;

			return aff;
		}
		/// <summary>
		/// Calcul le salaire d'un représentant
		/// </summary>
		/// <returns></returns>
		public override Double CalculSalaire()
		{
			Double sal;
			sal = SALAIRE_DE_BASE + (NB_IRIS_PAR_DEPLACEMENT * base.NbDeplacement) + (NB_IRIS_PAR_PRIME * base.NbPrime);

			return sal;
		}
	}
}
