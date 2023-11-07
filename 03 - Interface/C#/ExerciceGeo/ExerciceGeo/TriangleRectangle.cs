using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceGeo
{
	internal class TriangleRectangle
	{
		// Propriete
		public Double Base { get; set; }
		public Double Hauteur { get; set; }

		// Constructeur
		public TriangleRectangle(Double @base, Double hauteur)
		{
			Base = @base;
			Hauteur = hauteur;
		}

		// Methode 
		// Affichage
		public override string ToString()
		{
			String aff = "";
			aff += "Base& :  " + Base + " - Hauteur : " + Hauteur + " - Périmètre : " + Perimetre() + " - Aire : " + Aire();

			return aff;
		}

		// calcul du périmetre
		public Double Perimetre()
		{
			Double peri;
			Double hypothenuse = Math.Sqrt(Math.Pow(Hauteur, 2) + Math.Pow(Base, 2));
			peri = Hauteur + Base + hypothenuse;
			return peri;
		}

		// Calcul du aire
		public Double Aire()
		{
			Double aire;
			aire = (Hauteur * Base) / 2;

			return aire;

		}
	}
}
