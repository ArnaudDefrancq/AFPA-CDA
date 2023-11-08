using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceGeo
{
	public class Rectangle
	{
		// Propriete
		public int Longeur { get; set; }
		public int Largeur { get; set; }

		// Constructeur
		public Rectangle(int longeur, int largeur)
		{
			Longeur = longeur;
			Largeur = largeur;
		}

		// Methode
		// Affichage
		public override string ToString()
		{
			String aff = "";
			aff += "Longueur :  " + Longeur + " - Largeur : " + Largeur + " - Périmètre : " + Perimetre() + " - Aire : " + Aire() + " - c'est un carrée ? : " + (EstCarre() ? "oui" : "non");

			return aff;
		}

		// Methode pour calcul le perimetre
		public int Perimetre()
		{
			int peri = (Longeur + Largeur) * 2;
			return peri;
		}

		// Methode pour calcul l'aire
		public int Aire()
		{
			int aire = (Longeur * Largeur);
			return aire;
		}

		// Methode pour savoir si estcarré
		private bool EstCarre()
		{
			return (Longeur == Largeur) ? true : false;
		}
	}
}
