namespace Compte;
class Programm
{
	static void Main()
	{
		Client cli1 = new Client("EE111222", "Defrancq", "Arnaud", 012345678);
		Compte c1 = new Compte(0, cli1);

		Console.WriteLine(c1.ToString());

		int somme = 5000;

		Console.WriteLine("****************************************");
		Console.WriteLine("Déposer le montant " + somme);
		Console.WriteLine("Opération effectuée");
		Console.WriteLine("****************************************");

		c1.Crediter(somme);
		Console.WriteLine(c1.ToString());

		int debiter = 1000;
		Console.WriteLine("****************************************");
		Console.WriteLine("Montant débiter : " + debiter);
		Console.WriteLine("Opération effectuée");
		Console.WriteLine("****************************************");

		c1.Debiter(debiter);
		Console.WriteLine(c1.ToString());

		Client cli2 = new Client("EE333444", "Jean", "Marc", 012345678);
		Compte c2 = new Compte(0, cli2);

		Console.WriteLine(c2.ToString());
		int somme2 = 3000;

		Console.WriteLine("****************************************");
		Console.WriteLine("Créditer compte 2 avec le montant " + somme2 + " du compte 1");
		Console.WriteLine("Opération effectuée");
		Console.WriteLine("****************************************");

		c2.Crediter(somme2, c1);
		Console.WriteLine(c1.ToString());
		Console.WriteLine(c2.ToString());

		int debit2 = 1000;

		Console.WriteLine("****************************************");
		Console.WriteLine("débiter compte 1 avec le montant " + debit2 + " pour le compte 2");
		Console.WriteLine("Opération effectuée");
		Console.WriteLine("****************************************");
		c1.Debiter(debit2, c2);

		Console.WriteLine(c1.ToString());
		Console.WriteLine(c2.ToString());

		Console.WriteLine("****************************************");
		Console.WriteLine("il y a " + Compte.NbComtpe() + " compte créer");


	}
}