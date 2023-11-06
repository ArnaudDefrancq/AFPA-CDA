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
		public String? couleur { get; set; }
		public String marque { get; set; }
		public String modele { get; set; }
		public int? nbKilometre { get; set; }
		public String? motorisation { get; set; }

		// Constructeur
		public Voiture(string? couleur, string marque, string modele, int? nbKilometre, string? motorisation)
		{
			this.couleur = couleur;
			this.marque = marque;
			this.modele = modele;
			this.nbKilometre = nbKilometre;
			this.motorisation = motorisation;
		}

		public override String ToString()
		{
			String aff;

			aff = "Cette voiture est une " + modele + " de la marque " + marque + " ,de couleur " + couleur + " ,de motorisation " + motorisation + ",avec " + nbKilometre + " kiolmètres";

			return aff;
		}

		public int rouler(int km)
		{
			nbKilometre = km + nbKilometre;

			return (int)nbKilometre;
		}


	}
}
