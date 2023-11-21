using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace APP.CLASS
{
	internal class GestionDonnees
	{
		// Propriété
		public List<Produits> ListProd { get; set; }

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
			String path = "U:\\59011-82-04\\AFPA-CDA\\03 - Interface\\C# - Interface\\CRUD\\ExoCRUD\\APP\\JSON\\DB.json";

			String json = JsonConvert.SerializeObject(ListProd);

			File.WriteAllText(path, json);
		}

		/// <summary>
		/// Va chercher les données dans le JSON
		/// </summary>
		/// <returns>Une list d'objet Produits</returns>
		public List<Produits> GetListProd()
		{
			String path = "U:\\59011-82-04\\AFPA-CDA\\03 - Interface\\C# - Interface\\CRUD\\ExoCRUD\\APP\\JSON\\DB.json";

			List<Produits> prods = new List<Produits>() { };

			try
			{

				if (!File.Exists(path))
				{
					Console.WriteLine("Pas de fichier");
				}
				else
				{
					String JSON = File.ReadAllText(path);
					if (JsonConvert.DeserializeObject<List<Produits>>(JSON) != null)
					{
						prods = JsonConvert.DeserializeObject<List<Produits>>(JSON);
					}

				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			return prods;
		}
	}

}
