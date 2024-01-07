using gestionStock.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace gestionStock.Models.Services
{
	public class CategorieService
	{
		private readonly GestionStocksDBContext _context;
		public CategorieService(GestionStocksDBContext context)
		{
			_context = context;
		}

		public void AddCategory(Categorie c)
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
			return _context.Categories.Include("LesArticles").Include("LeTypeProduit").ToList();
		}

		public Categorie GetCategorieById(int id)
		{
			return _context.Categories.Include("LesArticles").Include("LeTypeProduit").FirstOrDefault(p => p.IdCategorie == id);
		}

		public void UpdateCategorie(Categorie c)
		{
			_context.SaveChanges();
		}
	}
}
