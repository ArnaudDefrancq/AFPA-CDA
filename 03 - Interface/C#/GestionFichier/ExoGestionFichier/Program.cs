namespace ExoGestionFichier;

class Program
{
	/// <summary>
	///	Permet de lire dans un fichier text. Avec StreamReader
	/// </summary>
	//public static void LectureFichier()
	//{
	//	String ligne = " ";
	//	try
	//	{
	//		StreamReader fichierTest = new StreamReader("U:\\59011-82-04\\AFPA-CDA\\03 - Interface\\C#\\GestionFichier\\ExoGestionFichier\\test.txt"); // Ouvre le fichier 

	//		ligne = fichierTest.ReadLine(); // Lis la première ligne du fichier et la stock dans la variable ligne

	//		while (ligne != null) // Tant que ligne n'est pas null, on lit l'ensemble du fichier ligne par ligne
	//		{
	//			Console.WriteLine(ligne);
	//			ligne = fichierTest.ReadLine();
	//		}
	//		fichierTest.Close(); // Ferme le ficher
	//		Console.ReadLine();
	//	}
	//	catch (Exception ex)
	//	{
	//		Console.WriteLine(ex.Message); // Si problème on affiche le message d'erreur
	//	}
	//}


	public static void LectureFichier(String emplacementFichier)
	{
		try
		{
			foreach (String ligne in File.ReadLines(emplacementFichier))
			{
				Console.WriteLine(ligne);
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	/// <summary>
	/// Ecrit dans un fichier texte exisant
	/// </summary>
	/// <param name="ecriture"></param>
	/// <param name="emplacementFichier"></param>
	public static void EcrireDansFichier(String ecriture, String emplacementFichier)
	{
		if (File.Exists(emplacementFichier))
		{
			using (StreamWriter ligneAjout = File.AppendText(emplacementFichier))
			{
				ligneAjout.WriteLine(ecriture);
			}
		}
		else
		{
			Console.WriteLine("Pas de fichier");
		}
	}

	//public static bool CreationFichierJSON(String emplacementFichier)
	//{

	//}
	static void Main()
	{
		//String path = "U:\\59011-82-04\\AFPA-CDA\\03 - Interface\\C#\\GestionFichier\\ExoGestionFichier\\ExoGestionFichier.csproj\\";
		//String directoryPath = Directory.GetCurrentDirectory();
		//String nomFichier = "test.txt";
		//String emplacementFichier = directoryPath + nomFichier;

		String emplacementFichier = "U:\\59011-82-04\\AFPA-CDA\\03 - Interface\\C#\\GestionFichier\\ExoGestionFichier\\test.txt";
		String ecriture = "Ligne supp";



		EcrireDansFichier(ecriture, emplacementFichier);
		LectureFichier(emplacementFichier);

	}

}
