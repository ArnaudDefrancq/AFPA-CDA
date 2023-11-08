using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceGeo
{
	public class Pave : Rectangle
	{


		// Propriete
		public int Hauteur { get; set; }
		// Constructeur
		public Pave(int longeur, int largeur, int hauteur) : base(longeur, largeur)
		{
			Hauteur = hauteur;
		}

		// Methode
		// Affichage
		public override string ToString()
		{
			String aff = "";
			aff += "Périmètre : " + Perimetre() + " - Volume : " + Volume();
			return aff;
		}

		/// <summary>
		/// Calcul le périmètre d'un pavé
		/// </summary>
		/// <returns></returns>
		new public int Perimetre()
		{
			int peri;
			peri = base.Perimetre() * 2 + Hauteur * 4;

			return peri;
		}

		/// <summary>
		/// Calcul le volume d'un pavé
		/// </summary>
		/// <returns></returns>
		public int Volume()
		{
			int vol;
			vol = base.Aire() * Hauteur;

			return vol;
		}
	}
}
