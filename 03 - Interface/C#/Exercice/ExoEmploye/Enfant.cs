using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExoEmploye.Program;

namespace ExoEmploye
{
	internal class Enfant
	{
		// Propriete
		public String Nom { get; set; }
		public int Age { get; set; }

		// Constructeur
		public Enfant(string nom, int age)
		{
			Nom = nom;
			Age = age;
		}

		// Methode
		// Affichage
		public override string ToString()
		{
			String aff = "";
			aff += "Nom de l'enfant : " + Nom + "\n";
			aff += "Age de l'enfant " + Age + "\n";

			return aff;
		}

		// Determine si il ya des cheque noel
		//public int MontantCheque()
		//{
		//	if (Age >= 0 && Age < 11)
		//	{
		//		return 20;
		//	}
		//	else if (Age < 16)
		//	{
		//		return 30;
		//	}
		//	else if (Age < 19)
		//	{
		//		return 50;
		//	}
		//	return 0;
		//}

		// Autre facon
		public valeurNoel ChequeNoel2()
		{
			if (Age < 11)
			{
				return valeurNoel.C20;
			}
			else if (Age < 16)
			{
				return valeurNoel.C30;
			}
			else if (Age < 19)
			{
				return valeurNoel.C50;
			}
			return 0;


		}
	}
}
