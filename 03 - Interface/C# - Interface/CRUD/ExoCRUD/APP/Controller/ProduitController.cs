﻿using APP.Helpers;
using APP.Models.Data;
using APP.Models.Dtos;
using APP.Models.Profiles;
using APP.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Controller
{
	public class ProduitController
	{
		public ProduitController()
		{
		}

		public List<ProduitDto> GetAllProduits()
		{
			ProduitProfile profile = new ProduitProfile();
			List<ProduitDto> produitDtos = profile.produitDto();
			return produitDtos;
		}

		public void CreateProduit(Produits p)
		{
			ProduitService service = new ProduitService();
			service.AddProduit(p);

		}
	}
}
