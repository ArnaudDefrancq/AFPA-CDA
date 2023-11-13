namespace JeuSpaceInvaders.Class;

class Program
{
	static void Main()
	{
		int nbLigne = 10;
		int nbColonnes = 20;

		List<Invaders> invaders = new List<Invaders>();

		Invaders invaders1 = new Invaders();
		Invaders invaders2 = new Invaders();
		Invaders invaders3 = new Invaders();
		Invaders invaders4 = new Invaders();
		Invaders invaders5 = new Invaders();

		invaders.Add(invaders1);
		//invaders.Add(invaders2);
		//invaders.Add(invaders3);
		//invaders.Add(invaders4);
		//invaders.Add(invaders5);




		Space jeu = new Space(10, 20, invaders);
		//jeu.Affiche();

		jeu.VisuMechant();

	}
}
