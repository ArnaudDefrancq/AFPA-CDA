using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjoutDataGrid
{

	class Produits
	{
		public int IdProd { get; set; }
		public int Quantite { get; set; }
		public String LibelleProd { get; set; }

		public Produits(int idProd, int quantite, string libelleProd)
		{
			IdProd = idProd;
			Quantite = quantite;
			LibelleProd = libelleProd;
		}

	}
}
