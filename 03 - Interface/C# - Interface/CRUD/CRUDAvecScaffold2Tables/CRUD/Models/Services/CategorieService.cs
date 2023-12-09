using CRUD.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Models.Services
{
	public class CategorieService
	{
		private readonly ImmobilierDBContext _context;
		public CategorieService(ImmobilierDBContext context)
		{
			_context = context;
		}

		public void AddCategorie(Categorie c)
		{
			if (c == null)
			{
				throw new ArgumentNullException(nameof(c));
			}
			_context.Categories.Add(c);
			_context.SaveChanges();
		}

		public void DeleteCategorie(Categorie c)
		{
			//si l'objet personne est null, on renvoi une exception
			if (c == null)
			{
				throw new ArgumentNullException(nameof(c));
			}
			// on met à jour le context
			_context.Categories.Remove(c);
			_context.SaveChanges();
		}

		public IEnumerable<Categorie> GetAllCategories()
		{
			return _context.Categories.ToList();
		}

		public Categorie GetCategorieById(int id)
		{
			return _context.Categories.FirstOrDefault(p => p.IdCategorie == id);
		}

		public void UpdateCategorie(Categorie c)
		{
			_context.SaveChanges();
		}
	}
}
