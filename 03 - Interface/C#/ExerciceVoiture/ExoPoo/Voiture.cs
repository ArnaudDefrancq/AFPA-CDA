using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoPoo
{
	internal class Voiture
	{



		// propriete de la class. Le "?" permet de dire null ou non
		public String Couleur { get; set; }
		public String Marque { get; set; }
		public String Modele { get; set; }
		public int NbKilometre { get; set; }
		public MotorisationEnum Motorisation { get; set; }

		// Constructeur
		public Voiture(string couleur, string marque, string modele, int nbKilometre = 0, MotorisationEnum motorisation)
		{
			Couleur = couleur;
			Marque = marque;
			Modele = modele;
			NbKilometre = nbKilometre;
			Motorisation = motorisation;
		}

		public Voiture(string marque, string modele)
		{
			Marque = marque;
			Modele = modele;
		}

		public override String ToString()
		{
			String aff;

			aff = "Cette voiture est une " + Modele + " de la marque " + Marque + " ,de couleur " + Couleur + " ,de motorisation " + Motorisation + ",avec " + NbKilometre + " kiolmètres";

			return aff;
		}

		public int rouler(int km)
		{
			return NbKilometre += km;
		}


	}
}
