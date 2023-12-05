using CRUD.Models.Data;
using CRUD.Models.Profiles;
using CRUD.Models.Services;
using System.Collections.Generic;

namespace CRUD.Controllers
{
	public class CategorieController
	{
		private CategorieService _service;

		public CategorieController()
		{
			_service = new CategorieService();
		}

		public List<Categorie> GetAllCategories()
		{
			List<Categorie> produits = _service.GetAllCategories();
			return produits;
		}

		public void CreateCategorie(Categorie c)
		{
			_service.AddCategorie(c);
		}

		public void DeleteCategorie(Categorie c)
		{
			_service.DeleteCategorie(c);
		}

		public void UpdateCategorie(Categorie cModif)
		{
			_service.UpdateCategorie(cModif);
		}
	}
}
