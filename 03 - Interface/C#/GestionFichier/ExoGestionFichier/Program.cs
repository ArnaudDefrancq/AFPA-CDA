using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

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
	/// Ecrit une string dans un fichier texte exisant
	/// </summary>
	/// <param name="ecriture"></param>
	/// <param name="emplacementFichier"></param>
	public static void EcrireDansFichier(String ecriture, String emplacementFichier)
	{
		try
		{
			if (File.Exists(emplacementFichier))
			{
				File.WriteAllText(emplacementFichier, ecriture);
			}
			else
			{
				Console.WriteLine("Pas de fichier - Veuillez créer le fichier");
			}
		}
		catch (Exception ex)
		{
			Console.Write(ex.Message);
		}
	}

	/// <summary>
	/// Ajoute une liste de string dans un fichier texte
	/// </summary>
	/// <param name="listeString"></param>
	/// <param name="emplacementFichier"></param>
	public static void EcrireUneListeDansFichier(List<String> listeString, String emplacementFichier)
	{
		if (File.Exists(emplacementFichier))
		{
			File.WriteAllLines(emplacementFichier, listeString);
		}
		else
		{
			Console.WriteLine("Pas de fichier - Veuillez créer le fichier");
		}
	}

	/// <summary>
	/// Permet de créer un fichier .json
	/// </summary>
	/// <param name="emplacementFichier"></param>
	/// <returns></returns>
	public static void CreationFichierJSON(String emplacementFichier, Contact contact)
	{
		String json = JsonSerializer.Serialize(contact);

		try
		{
			if (File.Exists(emplacementFichier))
			{
				File.WriteAllText(emplacementFichier, json);
			}
			else
			{
				Console.WriteLine("Pas de fichier - Veuillez créer le fichier");
			}
		}
		catch (Exception ex)
		{
			Console.Write(ex.Message);
		}
	}

	/// <summary>
	/// Permet de lire un fichier JSON
	/// </summary>
	/// <param name="emplacementFichier"></param>
	public static void LireFichierJSON(String emplacementFichier)
	{

	}

	static void Main()
	{
		//String path = "U:\\59011-82-04\\AFPA-CDA\\03 - Interface\\C#\\GestionFichier\\ExoGestionFichier\\ExoGestionFichier.csproj\\";
		//String directoryPath = Directory.GetCurrentDirectory();
		//String nomFichier = "test.txt";
		//String emplacementFichier = directoryPath + nomFichier;
		//String monFichier = "test.txt";
		//String emplacementFichier = Path.Combine(Environment.CurrentDirectory, monFichier);

		//String emplacementFichier = "U:\\59011-82-04\\AFPA-CDA\\03 - Interface\\C#\\GestionFichier\\ExoGestionFichier\\test.txt";

		//String emplacementFichier = "C:\\Users\\Toyger\\OneDrive\\Bureau\\Git AFPA\\AFPA-CDA\\03 - Interface\\C#\\GestionFichier\\ExoGestionFichier\\test.txt";
		String pathDossierJson = "C:\\Users\\Toyger\\OneDrive\\Bureau\\Git AFPA\\AFPA-CDA\\03 - Interface\\C#\\GestionFichier\\ExoGestionFichier\\dossier\\test.json";

		//Console.WriteLine(emplacementFichier + monFichier);
		//String ecriture = "Ligne supp";
		List<String> listeString = new List<String>() { "item1", "item2", "item3" };

		Contact c1 = new Contact("Defrancq", "Arnaud", "nono@mail.com");

		//EcrireDansFichier(ecriture, emplacementFichier);
		//EcrireUneListeDansFichier(listeString, emplacementFichier);
		//LectureFichier(emplacementFichier);

		//CreationFichierJSON(pathDossierJson, c1);

		LireFichierJSON(pathDossierJson);
	}

}
