using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoPoo.Class
{
	public abstract class Employe
	{
		// Propriete
		public int Age { get; set; }
		public String Nom { get; set; }
		public String Prenom { get; set; }
		public Double Salaire { get; set; }

		// Constructeur
		public Employe(int age, string nom, string prenom)
		{
			Age = age;
			Nom = nom;
			Prenom = prenom;
		}

		// Methode
		// Affichage
		public override string ToString()
		{
			String aff = "";

			aff += "Nom :" + Nom + " - Prénom : " + Prenom + " - Age : " + Age + " - Salaire : " + Salaire + "\n";

			return aff;
		}

		/// <summary>
		/// Affiche le ToString
		/// </summary>
		public void Afficher()
		{
			Console.WriteLine(this);
		}

		/// <summary>
		/// Calcul le salaire de l'employe
		/// </summary>
		/// <returns>Double</returns>
		public abstract Double CalculSalaire();
	}
}
