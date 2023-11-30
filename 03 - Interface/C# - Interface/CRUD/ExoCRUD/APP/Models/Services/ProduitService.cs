using APP.Helpers;
using APP.Models.Data;
using APP.Models.Dtos;
using APP.Models.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Models.Service
{
	public class ProduitService
	{
		public ProduitService()
		{
		}

		public void AddProduit(Produits p)
		{
			GestionDonnees context = new GestionDonnees();
			context.AjouterDonneeJSON(p);
		}

		public void DeleteProduit(Produits p)
		{
			GestionDonnees context = new GestionDonnees();
			context.SupprimerDonneeJson(p);
		}

		public List<Produits> GetAllProduits()
		{
			GestionDonnees context = new GestionDonnees();
			List<Produits> p = context.DownloaderDonnees();
			return p;
		}

		public void GetProduitById()
		{

		}

		public void UpdateProduit(Produits p)
		{
			GestionDonnees context = new GestionDonnees();
			context.UpdateDonneeJson(p);
		}

	}
}
