using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuSpaceInvaders.Class
{
	public class Space
	{
		// Propriete
		public int NbLigne { get; set; }
		public int NbColonnes { get; set; }

		// Constructeur
		public Space(int nbLigne, int nbColonnes)
		{
			NbLigne = nbLigne;
			NbColonnes = nbColonnes;
		}

		// Methode
		// Affichage
	}
}
