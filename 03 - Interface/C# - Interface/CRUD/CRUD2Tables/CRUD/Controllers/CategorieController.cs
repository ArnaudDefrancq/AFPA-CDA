using CRUD.Models.Data;
using CRUD.Models.Services;
using System.Collections.Generic;

namespace CRUD.Controllers
{
	public class CategorieController
	{
		public CategorieController()
		{
		}

		public List<Categorie> GetAllCategories()
		{
			CategorieService service = new CategorieService();
			List<Categorie> produits = service.GetAllCategories();
			return produits;
		}

		public void CreateCategorie(Categorie c)
		{
			CategorieService service = new CategorieService();
			service.AddCategorie(c);
		}

		public void DeleteCategorie(Categorie c)
		{
			CategorieService service = new CategorieService();
			service.DeleteCategorie(c);
		}

		public void UpdateCategorie(Categorie cModif)
		{
			CategorieService service = new v();
			service.UpdateCategorie(cModif);
		}
	}
}
