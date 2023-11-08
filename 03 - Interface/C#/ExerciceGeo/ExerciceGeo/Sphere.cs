using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceGeo
{
	public class Sphere : Cercle
	{
		// Constructeur
		public Sphere(double diametre) : base(diametre)
		{
			Rayon = diametre / 2;
		}

		// Methode
		// Affichage
		public override string ToString()
		{
			String aff = "";
			aff += base.ToString() + " - Volume de la sphère : " + Volume();
			return aff;
		}

		/// <summary>
		/// Calcul le volume de la shpère
		/// </summary>
		/// <returns>Double</returns>
		public Double Volume()
		{
			Double vol;
			vol = (4 * Math.PI * Math.Pow(Rayon, 3)) / 3;

			return Math.Round(vol, 2);
		}
	}
}
