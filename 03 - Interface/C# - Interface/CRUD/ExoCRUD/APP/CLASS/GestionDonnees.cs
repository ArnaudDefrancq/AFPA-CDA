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

		public List<Produits> ListProd { get; set; }

		public GestionDonnees(List<Produits> listProd)
		{
			ListProd = listProd;
		}


		public void CreateJSON()
		{
			String path = "U:\\59011-82-04\\AFPA-CDA\\03 - Interface\\C# - Interface\\CRUD\\ExoCRUD\\APP\\JSON\\DB.json";

			String json = JsonConvert.SerializeObject(ListProd);

			File.WriteAllText(path, json);
		}

		public List<Produits> GetListProd()
		{
			String path = "U:\\59011-82-04\\AFPA-CDA\\03 - Interface\\C# - Interface\\CRUD\\ExoCRUD\\APP\\JSON\\DB.json";

			String JSON = File.ReadAllText(path);

			List<Produits> prods = new List<Produits>();

			prods = JsonConvert.DeserializeObject<List<Produits>>(JSON);

			return prods;
		}
	}

}
