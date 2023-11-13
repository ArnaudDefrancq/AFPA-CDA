using System.Security.Cryptography.X509Certificates;

namespace ExoEmploye;

class Program
{
	static void Main()
	{
		//Employe e = new Employe("defrancq", "arnaud", "01/01/2021", 10, "compta");

		//Console.WriteLine(e.ToString());

		DateTime dateTime = DateTime.Now;

		bool EstVirement(DateTime date)
		{
			String dateVirement = "30/11";

			DateTime dateVirementConvert = Convert.ToDateTime(dateVirement);

			int result = DateTime.Compare(dateVirementConvert, date);

			return (result < 0) ? true : false;
		}

		if (EstVirement(dateTime))
		{
			Console.WriteLine("Virement effectué");
		}
		else
		{
			Console.WriteLine("Virement pas effectué");
		}

		Console.WriteLine("*******************************");
		Agence a1 = new Agence("bonne", "314 rue de lille", 59000, "Lille", false);
		Agence a2 = new Agence("cuisine", "314 rue de paris", 78000, "Paris", true);
		Agence a3 = new Agence("marche", "314 rue de lyon", 62000, "Lyon", false);

		Enfant enfant1 = new Enfant("Mick", 3);
		Enfant enfant2 = new Enfant("Mick", 20);
		Enfant enfant3 = new Enfant("Mick", 14);
		Enfant enfant4 = new Enfant("Mick", 11);
		Enfant enfant5 = new Enfant("Mick", 1);
		Enfant enfant6 = new Enfant("Mick", 15);

		List<Enfant> enfants1 = new List<Enfant> { enfant2, enfant1 };
		List<Enfant> enfants2 = new List<Enfant> { enfant2, enfant6, enfant4 };
		List<Enfant> enfants3 = new List<Enfant> { enfant4, enfant3, enfant6 };
		List<Enfant> enfants4 = new List<Enfant> { };


		Employe e2 = new Employe("xarc", "Jean", "02/05/1996", 34, "fictif", a1, enfants1);
		//Employe e3 = new Employe("Paul", "Jean", "04/11/2023", 30, "daltonien", a1, enfants3);
		//Employe e4 = new Employe("hierre", "Pierre", "03/06/2020", 15, "stage", a2, enfants2);
		//Employe e5 = new Employe("Monique", "Nicmo", "07/12/2003", 10, "Alternant", a2, enfants4);
		//Employe e6 = new Employe("Francine", "Farine", "14/02/1980", 4, "Change", a3, enfants2);


		//List<Employe> employes = new List<Employe> { e2, e3, e4, e5, e6 };
		//Console.WriteLine("*******************************");
		//Console.WriteLine("Nombre employe : " + employes.Count());
		//Console.WriteLine("*******************************");

		//IEnumerable<Employe> sort;
		//sort = employes.OrderBy(e => e.Nom).ThenBy(e => e.Prenom);
		//Console.WriteLine("*******************************");
		//foreach (Employe emp in sort)
		//{
		//	Console.WriteLine(emp);
		//}
		//Console.WriteLine("*******************************");
		//sort = employes.OrderBy(e => e.Service).ThenBy(e => e.Nom).ThenBy(e => e.Prenom);
		//foreach (Employe emp in sort)
		//{
		//	Console.WriteLine(emp.ToString());
		//}
		//Console.WriteLine("*******************************");

		//int MasseSalarial(List<Employe> emp)
		//{
		//	int total = 0;
		//	foreach (Employe e in emp)
		//	{
		//		total += e.MasseSalarial();
		//	}
		//	return total;
		//}

		//Console.WriteLine("La masse salarial est de " + MasseSalarial(employes) + " euro");
		Console.WriteLine("*******************************");


		Console.WriteLine(e2.ToString());

	}
	public enum valeurNoel
	{
		C20,
		C30,
		C50
	}
}