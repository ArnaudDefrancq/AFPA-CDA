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
		public List<Produits> ListProd { get; set; } = new List<Produits>();
		public static String Path { get; set; } = "U:\\59011-82-04\\AFPA-CDA\\03 - Interface\\C# - Interface\\CRUD\\ExoCRUD\\APP\\JSON\\DB.json";

		// Constructeur
		public GestionDonnees(List<Produits> listProd)
		{
			ListProd = listProd;
		}



		// Méthodes

		/// <summary>
		/// Créer les données dans le fichier JSON
		/// </summary>
		public void CreateJSON()
		{
			String json = JsonConvert.SerializeObject(ListProd);

			File.WriteAllText(Path, json);
		}

		/// <summary>
		/// Va chercher les données dans le JSON
		/// </summary>
		/// <returns>Une list d'objet Produits</returns>
		public List<Produits> GetListProd()
		{
			List<Produits> prods = new List<Produits>();

			try
			{
				if (File.Exists(Path))
				{
					string json = File.ReadAllText(Path);
					prods = JsonConvert.DeserializeObject<List<Produits>>(json);
				}
				else
				{
					Console.WriteLine("Le fichier JSON n'existe pas.");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
			}

			return prods;
		}

		/// <summary>
		/// Ajout de données dans le fichier JSON
		/// </summary>
		public void AjouterDonneeJSON(Produits p)
		{
			String json = JsonConvert.SerializeObject(p);

			File.WriteAllText(Path, json);
		}
	}

}
