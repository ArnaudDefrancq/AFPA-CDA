using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoPoo.Class
{
	abstract public class Commerciaux : Employe
	{
		// Propriete
		public Double NbDeplacement { get; set; }
		public Double NbPrime { get; set; }

		// Constructeur
		public Commerciaux(int age, string nom, string prenom, Double nbDeplacement, Double nbPrime) : base(age, nom, prenom)
		{
			NbDeplacement = nbDeplacement;
			NbPrime = nbPrime;
		}

		// Methode
		// Affichage

	}
}
