// See https://aka.ms/new-console-template for more information
int pognon = 1000;

/**
 * Affiche le pognon
 */
static void start()
{

}

/**
 * Mise du joueur
 * 
 * param int nbPognon total du pognon du joueur
 * 
 * return int mise du joueur
 */
static int mise(int nbPognon)
{

}


/**
 * Distrubution des cartes
 * 
 * param List<int> tabCarte tableau qvec les cartes disponible
 * 
 * return int valeur de la carte
 */
static int distribuer(List<int> tabCarte)
{

}

/**
 * Affiche la mise, la carte du croupier, les cartes du joueur et le pognon disponible 
 * 
 * param int mise mise du joueur
 * param List<int> carteCroupier carte piocher par le croupier
 * param List<int> carteJoueur carte piocher par la joueur
 * param int pognonJoueur pognon du joueur
 */
static void display(int mise, List<int> carteCroupier, List<int> carteJoueur, int pognonJoueur)
{

}

/**
 * Tour du joueur, met a jour la list des cartes du joueur
 * 
 * param List<int>carteJoueur liste des cartes du joueur
 * 
 * return List<int> liste des cartes du joueur 
 */
static List<int> playerTurn(List<int> carteJoueur)
{
}

/**
 * Permet l'état de la partie: si le joueur n'a pas plus de 21, si il a 21, si il a plus ou moins que la banque
 * 
 * param int tour 
 * 
 * return int 
 */
static int check(int tour)
{

}

/**
 * Tirage des cartes du croupier et met à jour les cartes du croupier
 * 
 * param List<int> carteCroupier Liste des cartes du croupier
 * param List<int> carteJoueur Liste des cartes du joueur
 * param List<int> carteDisponible Liste des cartes disponible
 * 
 * return List<int> 
 */
static List<int> bankTurn(List<int> carteCroupier, List<int> carteJoueur, List<int> carteDisponible)
{
	while (carteCroupier.Sum() < carteJoueur.Sum() || carteCroupier.Sum() == 21 || carteCroupier.Sum() > 21)
	{
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

/**
 * Check la win du joueur
 * 
 * param List<int> carteCroupier Liste des cartes du croupier
 * param List<int> carteJoueur Liste des cartes du 
 */
static void endTurn(List<int> cartesCroupier, List<int> cartesJoueur)
{

}


