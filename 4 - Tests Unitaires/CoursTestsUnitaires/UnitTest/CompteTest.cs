using System.Numerics;
using TestsUnitaires;

namespace UnitTest
{
	public class CompteTest
	{
		// Permet d'init le compte pour l'ensemble des différents tests
		Compte compte;

		[SetUp]
		public void Setup()
		{
			// Permet d'init le compte pour l'ensemble des différents tests
			double soldeDepart = 11.99;
			compte = new Compte("Mr Toto", soldeDepart);
		}

		[Test]
		public void Debit_MontantValide()
		{
			// Init des variables pour le test
			double montantDebite = 4.55;
			double attendu = 7.44;


			// On récupère la propriete avec le solde du compte 
			compte.Debit(montantDebite);

			// On regarde si on a bien le même resultat
			double soldeActuel = compte.Solde;
			Assert.AreEqual(attendu, soldeActuel, 0.001, "Comtpe mal débité");
		}

		[Test]
		public void Debit_MontantNegatif()
		{
			// Init des variables pour le test
			double montantDebite = -4;

			// On verifie que la methode Debit sort bien cette exeption
			Assert.Throws<ArgumentOutOfRangeException>(() => compte.Debit(montantDebite));
		}

		[Test]
		public void Debit_MontantSuperieurSolde()
		{
			// Init des variables pour le test
			double montantDebite = -44.55;

			// On verifie que la methode Debit sort bien cette exeption
			Assert.Throws<ArgumentOutOfRangeException>(() =>
		   compte.Debit(montantDebite));


		}
	}
}