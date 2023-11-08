using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceGeo
{
	public class Pyramide : TriangleRectangle
	{


		// Propiete
		public Double Profondeur { get; set; }

		// Constructeur
		public Pyramide(double @base, double hauteur, double profondeur) : base(@base, hauteur)
		{
			Profondeur = profondeur;
		}

		// Methode
		// Affichage
		public override string ToString()
		{
			String aff = "";
			aff += base.ToString() + " - Profondeur: " + Profondeur + " - Périmetre pyramide: " + Perimetre() + " - Volume :" + Volume();

			return aff;
		}

		/// <summary>
		/// Calcule le périmetre d'une pyramide
		/// </summary>
		/// <returns>Double</returns>
		new public Double Perimetre()
		{
			Double peri;
			peri = Math.Round(base.Perimetre() * 2 + Profondeur * 3, 2);

			return peri;
		}

		/// <summary>
		/// Calcul le volume d'une pyramide
		/// </summary>
		/// <returns>Double</returns>
		public Double Volume()
		{
			Double vol;
			vol = base.Aire() * Profondeur;

			return vol;
		}
	}
}
