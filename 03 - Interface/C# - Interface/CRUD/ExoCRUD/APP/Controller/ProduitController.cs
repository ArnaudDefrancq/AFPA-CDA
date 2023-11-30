using APP.Helpers;
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
			List<ProduitDto> produitDtos = profile.produitDtoOut();
			return produitDtos;
		}

		public void CreateProduit(Produits p)
		{
			ProduitService service = new ProduitService();
			service.AddProduit(p);
		}

		public void DeleteProduit(ProduitDto pDto)
		{
			ProduitProfile profile = new ProduitProfile();
			Produits p = profile.produitDtoIn(pDto);

			ProduitService service = new ProduitService();
			service.DeleteProduit(p);
		}

		public void UpdateProduit(ProduitDto produitModif, ProduitDto produitSansModif)
		{
			ProduitProfile profile = new ProduitProfile();
			Produits p = profile.produitDtoUpdate(produitModif, produitSansModif);

			ProduitService service = new ProduitService();
			service.UpdateProduit(p);
		}
	}
}
