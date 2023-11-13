// See https://aka.ms/new-console-template for more information
// 1 - Sous-Programmes
// 1.1 - Géométrie

class MainClass
{
	public static void ligneSansReturn(int n, Char l)
	{
		for (int i = 0; i < n; i++)
		{
			Console.Write(l);
			Console.Write(' ');
		}
	}

	public static void ligneAvecReturn(int n, Char l)
	{
		int test = (n + 2) - 1;
		Console.Write("\n");
		for (int i = 0; i < n; i++)
		{
			Console.Write(l);
			espace(n + test);
			Console.Write(l);
			Console.Write("\n");
		}
	}

	public static void espace(int n)
	{
		for (int i = 0; i < n; i++)
		{
			Console.Write(" ");
		}
	}

	public static void carre(int n, Char l)
	{
		ligneSansReturn(n, l);

		ligneAvecReturn(n - 2, l);

		ligneSansReturn(n, l);

	}

	public static void unCaractereSansReturn(int i, Char l)
	{

	}

	public static void Main(String[] args)
	{
		Char c = 'x';
		int number = 5;
		carre(number, c);
	}


}
// 1.2 - Arithmétique

//int number = 562;

//static int unites(int n)
//{
//	int unit = n % 10;
//	return unit;
//}

//Console.WriteLine(unites(number));

//static int diz(int n)
//{
//	int dizaine = (n / 10) % 10;

//	return dizaine;
//}
//Console.WriteLine(diz(number));

//static int extrait(int n, int p)
//{
//	String number = n.ToString();

//	int choix = Convert.ToInt32(number[p]);

//	return choix;
//}

//extrait(number, 1);