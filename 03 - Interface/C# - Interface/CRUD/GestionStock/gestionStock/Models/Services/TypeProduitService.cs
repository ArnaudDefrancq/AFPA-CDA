using gestionStock.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace gestionStock.Models.Services
{
	public class TypeProduitService
	{
		private readonly GestionStocksDBContext _context;
		public TypeProduitService(GestionStocksDBContext context)
		{
			_context = context;
		}

		public void AddTypesproduit(Typesproduit tp)
		{
			if (tp == null)
			{
				throw new ArgumentNullException(nameof(tp));
			}
			_context.Typesproduits.Add(tp);
			_context.SaveChanges();
		}

		public void DeleteTypesproduit(Typesproduit tp)
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

		public IEnumerable<Typesproduit> GetAllTypesproduits()
		{
			return _context.Typesproduits.Include("LesCategories").ToList();
		}

		public Typesproduit GetTypesproduitById(int id)
		{
			return _context.Typesproduits.Include("LesArticles").FirstOrDefault(p => p.IdTypeProduit == id);
		}

		public void UpdateTypesproduit(Typesproduit tp)
		{
			_context.SaveChanges();
		}
	}
}
