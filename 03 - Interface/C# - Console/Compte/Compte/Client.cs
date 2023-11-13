using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compte
{
	internal class Client
	{
		// propriétés
		public String Cin { get; set; }
		public String Nom { get; set; }
		public String Prenom { get; set; }
		public int Tel { get; set; }

		// Constructeur
		public Client(string cin, string nom, string prenom, int tel)
		{
			Cin = cin;
			Nom = nom;
			Prenom = prenom;
			Tel = tel;
		}

		// Methode
		public override string ToString()
		{
			String aff;

			aff = "CIN : " + Cin + " ,nom : " + Nom + " ,prénom : " + Prenom + " , numéro de téléphone : " + Tel;

			return aff;
		}
	}
}
