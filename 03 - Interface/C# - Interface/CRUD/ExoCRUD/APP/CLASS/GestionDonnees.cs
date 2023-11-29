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
		public List<Produits> ListProd { get; set; }
		public static String Path { get; set; } = "U:\\59011-82-04\\AFPA-CDA\\03 - Interface\\C# - Interface\\CRUD\\ExoCRUD\\APP\\JSON\\DB.json";
		//public static String Path { get; set; } = "C:\\Users\\Toyger\\OneDrive\\Bureau\\Git AFPA\\AFPA-CDA\\03 - Interface\\C# - Interface\\CRUD\\ExoCRUD\\APP\\JSON\\DB.json";

		//Constructeur
		public GestionDonnees(List<Produits> listProd)
		{
			ListProd = listProd;
		}

		public GestionDonnees()
		{
		}



		// Méthodes

		/// <summary>
		/// Créer les données dans le fichier JSON
		/// </summary>
		public void UploaderDonnees()
		{
			try
			{
				String json = System.Text.Json.JsonSerializer.Serialize(ListProd);
				if (!File.Exists(Path))
				{
					File.WriteAllText(Path, json);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Une erreur s'est produite lors de la création du fichier JSON : {ex.Message}");
			}
		}

		/// <summary>
		/// Va chercher les données dans le JSON
		/// </summary>
		/// <returns>Une list d'objet Produits</returns>
		public List<Produits> DownloaderDonnees()
		{
			List<Produits> prod = new List<Produits>();
			try
			{
				if (File.Exists(Path))
				{
					String json = File.ReadAllText(Path);
					return prod = System.Text.Json.JsonSerializer.Deserialize<List<Produits>>(json)!;
				}

			}
			catch (Exception ex)
			{
				Console.WriteLine($"Une erreur s'est produite lors de la création du fichier JSON : {ex.Message}");
			}

			return prod;
		}


		/// <summary>
		/// Ajout de données dans le fichier JSON
		/// </summary>
		public void AjouterDonneeJSON(Produits p)
		{
			List<Produits> prod = DownloaderDonnees();
			prod.Add(p);

			String json = JsonConvert.SerializeObject(prod);

			File.WriteAllText(Path, json);
		}

		public void SupprimerDonneeJson(Produits p)
		{
			List<Produits> prod = DownloaderDonnees();

			prod.Dump();

			if (prod.Contains(p))
			{
				prod.Dump();
			}

			//prod.Dump();
			//prod.Remove(p);
			//prod.Dump();
			//String json = JsonConvert.SerializeObject(prod);
			//File.WriteAllText(Path, json);


		}
	}

}
