using APP.Helpers;
using APP.Models.Data;
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
			GestionDonnees BDD = new GestionDonnees();
			BDD.AjouterDonneeJSON(p);
		}

		public void DeleteProduit(Produits p)
		{
			GestionDonnees BDD = new GestionDonnees();
			BDD.SupprimerDonneeJson(p);
		}

		public List<Produits> GetAllProduits()
		{
			GestionDonnees BDD = new GestionDonnees();
			List<Produits> p = BDD.DownloaderDonnees();
			p.Dump();
			return p;
		}

		public void GetProduitById()
		{

		}

		public void UpdateProduit(Produits p)
		{
			GestionDonnees BDD = new GestionDonnees();
			BDD.UpdateDonneeJson(p);
		}

	}
}
