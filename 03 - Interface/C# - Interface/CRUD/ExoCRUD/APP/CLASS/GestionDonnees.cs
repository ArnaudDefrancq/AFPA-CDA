using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Shapes;

namespace APP.CLASS
{
	public class GestionDonnees
	{
		// Propriété
		//public List<Produits> ListProd { get; set; }
		//public static String Path { get; set; } = "U:\\59011-82-04\\AFPA-CDA\\03 - Interface\\C# - Interface\\CRUD\\ExoCRUD\\APP\\JSON\\DB.json";
		public static String Path { get; set; } = "C:\\Users\\Toyger\\OneDrive\\Bureau\\Git AFPA\\AFPA-CDA\\03 - Interface\\C# - Interface\\CRUD\\ExoCRUD\\APP\\JSON\\DB.json";

		// Constructeur
		//public GestionDonnees(List<Produits> listProd)
		//{
		//	ListProd = listProd;
		//}



		// Méthodes

		/// <summary>
		/// Créer les données dans le fichier JSON
		/// </summary>
		//public void CreateJSON()
		//{
		//	try
		//	{
		//		string json = JsonConvert.SerializeObject(ListProd);
		//		File.WriteAllText(Path, json);
		//	}
		//	catch (Exception ex)
		//	{
		//		Console.WriteLine($"Une erreur s'est produite lors de la création du fichier JSON : {ex.Message}");
		//	}
		//}

		/// <summary>
		/// Va chercher les données dans le JSON
		/// </summary>
		/// <returns>Une list d'objet Produits</returns>
		public List<Produits> GetListProd()
		{


			if (File.Exists(Path))
			{
				string json = File.ReadAllText(Path);
				List<Produits> prods = JsonConvert.DeserializeObject<List<Produits>>(json);
				return prods;
			}
			else
			{
				Console.WriteLine("Le fichier JSON n'existe pas.");
				return new List<Produits>();
			}


		}


		/// <summary>
		/// Ajout de données dans le fichier JSON
		/// </summary>
		public void AjouterDonneeJSON(Produits p)
		{
			String json = JsonConvert.SerializeObject(p);

			File.AppendAllText(Path, json);
		}
	}

}
