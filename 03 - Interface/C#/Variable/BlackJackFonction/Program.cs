// See https://aka.ms/new-console-template for more information
List<int> carteCroupier = new List<int> { 8, 6 };
List<int> carteJoueur = new List<int> { 8, 4, 7 };
List<int> carteDisponible = new List<int> { 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6, 7, 7, 7, 7, 8, 8, 8, 8, 9, 9, 9, 9, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };

static List<int> bankTurn(List<int> carteCroupier, List<int> carteJoueur, List<int> carteDisponible)
{
	while (carteCroupier.Sum() > carteJoueur.Sum() || carteCroupier.Sum() != 21 || carteCroupier.Sum() < 21)
	{
		Console.WriteLine("test");
		Random random = new Random();
		int chiffre = random.Next(carteDisponible.Count());
		int carteSelectionner = carteDisponible[chiffre];

		if (carteSelectionner == 1 && carteCroupier.Sum() > 10)
		{
			carteCroupier.Add(1);
		}
		else if (carteSelectionner == 1 && carteCroupier.Sum() < 10)
		{
			carteCroupier.Add(11);
		}
		else
		{
			carteCroupier.Add(carteSelectionner);
		}

	}

	return carteCroupier;
}


bankTurn(carteCroupier, carteJoueur, carteDisponible);

foreach (int i in carteCroupier)
{
	Console.WriteLine(i);
}

