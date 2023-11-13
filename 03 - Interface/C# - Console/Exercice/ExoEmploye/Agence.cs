using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoEmploye
{
	internal class Agence
	{
		// Propriété
		public String Nom { get; set; }
		public String Adresse { get; set; }
		public int CodePostal { get; set; }
		public String Ville { get; set; }
		public bool RestoEntreprise { get; set; }

		// Constructeur
		public Agence(string nom, string adresse, int codePostal, string ville, bool restoEntreprise)
		{
			Nom = nom;
			Adresse = adresse;
			CodePostal = codePostal;
			Ville = ville;
			RestoEntreprise = restoEntreprise;
		}

		// Methode
		// Afficher
		public override string ToString()
		{
			String aff = "";
			aff += "Nom de l'agence : " + Nom + "\n";
			aff += "Adresse de l'agence : " + Adresse + "\n";
			aff += "Code postal : " + CodePostal + "\n";
			aff += "Ville : " + Ville + "\n";
			aff += RestoEntreprise ? "Possède un resto \n" : "N'a pas de resto donc tiket resto \n";

			return aff;
		}
	}
}
