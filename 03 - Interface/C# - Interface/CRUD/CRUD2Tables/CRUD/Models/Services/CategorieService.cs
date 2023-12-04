using CRUD.Models.Data;
using System.Collections.Generic;

namespace CRUD.Models.Services
{
	internal class CategorieService
	{
		public CategorieService()
		{
		}

		public void AddCategorie(Categorie c)
		{
			GestionDonnesContext context = new GestionDonnesContext();
			context.AjouterDonneeCategorieJSON(c);
		}

		public void DeleteCategorie(Categorie c)
		{
			GestionDonnesContext context = new GestionDonnesContext();
			context.SupprimerDonneeCategorieJson(c);
		}

		public List<Categorie> GetAllCategories()
		{
			GestionDonnesContext context = new GestionDonnesContext();
			List<Categorie> c = context.DownloaderDonneesCategorieJSON();
			return c;
		}

		public void GetProduitById()
		{

		}

		public void UpdateCategorie(Categorie c)
		{
			GestionDonnesContext context = new GestionDonnesContext();
			context.UpdateDonneeCategorieJson(c);
		}

	}
}
