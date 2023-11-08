namespace ExoPoo;

class Programm
{
	static void Main()
	{
		Voiture v = new Voiture("rouge", "Fiat", "Punto", 188000, MotorisationEnum.Diesel);
		Console.WriteLine(v.ToString());

		Voiture v2 = new Voiture("", "Citroën", "C4", 1000);
		Voiture v3 = new Voiture("Rouge", "Renault", "Kadjar", 0, "");

		Console.WriteLine(v2.ToString());
		Console.WriteLine(v3.ToString());

		v2.rouler(1000);
		Console.WriteLine(v2.ToString());


	}

}

public enum MotorisationEnum
{
	Diesel,
	Essence
}