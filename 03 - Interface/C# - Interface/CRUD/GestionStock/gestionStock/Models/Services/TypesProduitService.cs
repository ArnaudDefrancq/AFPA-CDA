using gestionStock.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace gestionStock.Models.Services
{
	public class TypesProduitService
	{
		private readonly GestionStocksDBContext _context;
		public TypesProduitService(GestionStocksDBContext context)
		{
			_context = context;
		}

		public void AddTypesproduit(TypesProduit tp)
		{
			if (tp == null)
			{
				throw new ArgumentNullException(nameof(tp));
			}
			_context.Typesproduits.Add(tp);
			_context.SaveChanges();
		}

		public void DeleteTypesproduit(TypesProduit tp)
		{
			//si l'objet personne est null, on renvoi une exception
			if (tp == null)
			{
				throw new ArgumentNullException(nameof(tp));
			}
			// on met à jour le context
			_context.Typesproduits.Remove(tp);
			_context.SaveChanges();
		}

		public IEnumerable<TypesProduit> GetAllTypesproduits()
		{
			return _context.Typesproduits.Include("LesCategories.LesArticles").ToList();
		}

		public TypesProduit GetTypesproduitById(int id)
		{
			return _context.Typesproduits.Include("LesCategories.LesArticles").FirstOrDefault(p => p.IdTypeProduit == id);
		}

		public void UpdateTypesproduit(TypesProduit tp)
		{
			_context.SaveChanges();
		}
	}
}
