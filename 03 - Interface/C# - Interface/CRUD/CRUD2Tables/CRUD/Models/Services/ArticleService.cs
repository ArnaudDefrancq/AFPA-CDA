using CRUD.Helpers;
using CRUD.Models.Data;
using System.Collections.Generic;

namespace CRUD.Models.Services
{
	public class ArticleService
	{
		private GestionDonnesContext _context;

		public ArticleService()
		{
			_context = new GestionDonnesContext();
		}

		public void AddArticle(Article a)
		{
			_context.AjouterDonneeArticleJSON(a);
		}

		public void DeleteArticle(Article a)
		{
			_context.SupprimerDonneeArticleJson(a);
		}

		public List<Article> GetAllArticles()
		{
			List<Article> a = _context.DownloaderDonneesArticleJSON();
			return a;
		}

		public void GetProduitById()
		{

		}

		public void UpdateArticle(Article a)
		{
			_context.UpdateDonneeArticleJson(a);
		}

	}
}
