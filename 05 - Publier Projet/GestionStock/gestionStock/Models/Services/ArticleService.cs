using gestionStock.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace gestionStock.Models.Services
{
	public class ArticleService
	{
		private readonly GestionStocksDBContext _context;
		public ArticleService(GestionStocksDBContext context)
		{
			_context = context;
		}

		public void AddArticle(Article a)
		{
			if (a == null)
			{
				throw new ArgumentNullException(nameof(a));
			}
			_context.Articles.Add(a);
			_context.SaveChanges();
		}

		public void DeleteArticle(Article a)
		{
			//si l'objet personne est null, on renvoi une exception
			if (a == null)
			{
				throw new ArgumentNullException(nameof(a));
			}
			// on met à jour le context
			_context.Articles.Remove(a);
			_context.SaveChanges();
		}

		public IEnumerable<Article> GetAllArticles()
		{
			return _context.Articles.Include("LaCategorie.LeTypeProduit").ToList();
		}

		public Article GetArticleById(int id)
		{
			return _context.Articles.Include("LaCategorie.LeTypeProduit").FirstOrDefault(p => p.IdArticle == id);
		}

		public void UpdateArticle(Article a)
		{
			_context.SaveChanges();
		}
	}
}
