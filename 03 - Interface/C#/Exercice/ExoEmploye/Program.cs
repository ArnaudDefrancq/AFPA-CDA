namespace ExoEmploye;

class Program
{
	static void Main()
	{
		Employe e = new Employe("defrancq", "arnaud", "01/01/2021", 10, "compta");

		Console.WriteLine(e.ToString());
	}
}