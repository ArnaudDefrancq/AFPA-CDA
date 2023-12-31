﻿using APP.Models.Data;
using APP.Models.Service;
using System.Collections.Generic;

namespace APP.Controller
{
	public class ProduitController
	{


		public ProduitController()
		{
		}

		public List<Produits> GetAllProduits()
		{
			ProduitService service = new ProduitService();
			List<Produits> produits = service.GetAllProduits();
			return produits;
		}

		public void CreateProduit(Produits p)
		{
			ProduitService service = new ProduitService();
			service.AddProduit(p);
		}

		public void DeleteProduit(Produits p)
		{
			ProduitService service = new ProduitService();
			service.DeleteProduit(p);
		}

		public void UpdateProduit(Produits pModif)
		{
			ProduitService service = new ProduitService();
			service.UpdateProduit(pModif);
		}
	}
}
