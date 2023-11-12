using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoGestionFichier
{
	public class Contact
	{
		// Propriete
		public String Nom { get; set; }
		public String Prenom { get; set; }
		public String Email { get; set; }

		// Constructeur
		public Contact(string nom, string prenom, string email)
		{
			Nom = nom;
			Prenom = prenom;
			Email = email;
		}

		// Methode
	}
}
