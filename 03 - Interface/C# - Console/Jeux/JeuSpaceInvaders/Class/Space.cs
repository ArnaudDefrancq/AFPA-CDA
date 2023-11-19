using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace JeuSpaceInvaders.Class
{
	public class Space
	{
		// Propriete
		public int NbLigne { get; set; }
		public int NbColonnes { get; set; }
		public Char[,] Grille { get; set; }

		// Constructeur
		public Space(int nbLigne, int nbColonnes)
		{
			NbLigne = nbLigne;
			NbColonnes = nbColonnes;
			Grille = InitGrille();
		}

		// Methode
		// Affichage
		public override string ToString()
		{
			String aff = "";


			return aff;
		}

		public Char[,] InitGrille()
		{
			Char[,] Grille = new Char[NbLigne, NbColonnes];

			for (int i = 0; i < NbLigne; i++)
			{

				for (int j = 0; j < NbColonnes; j++)
				{
					Grille[i, j] = ('o');
				}

			}

			return Grille;
		}


	}
}
