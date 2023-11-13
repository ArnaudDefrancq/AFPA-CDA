using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceGeo
{
	public class Cercle
	{
		// Propriete
		public Double Diametre { get; set; }
		public Double Rayon { get; set; }

		// Constructeur
		public Cercle(Double diametre)
		{
			Diametre = diametre;
			Rayon = Diametre / 2;
		}

		// Methode
		// Affichage
		public override string ToString()
		{
			String aff = "";
			aff += "Diametre :  " + Diametre + " - Périmètre : " + Perimetre() + " - Aire : " + Aire();

			return aff;
		}

		// Calcul perimetre
		public Double Perimetre()
		{
			Double peri;
			peri = Math.PI * Diametre;

			return peri;

		}

		// Calcul aire
		public Double Aire()
		{
			Double aire;
			aire = Math.PI * Math.Pow(Rayon, 2);

			return aire;
		}
	}
}
