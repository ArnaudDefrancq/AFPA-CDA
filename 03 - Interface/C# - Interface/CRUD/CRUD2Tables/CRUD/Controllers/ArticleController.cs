using CRUD.Models.Data;
using CRUD.Models.Services;
using System.Collections.Generic;

namespace CRUD.Controllers
{
	public class ArticleController
	{
		public ArticleController()
		{
		}

		public List<Article> GetAllArticles()
		{
			ArticleService service = new ArticleService();
			List<Article> produits = service.GetAllArticles();
			return produits;
		}

		public void CreateArticle(Article a)
		{
			ArticleService service = new ArticleService();
			service.AddArticle(a);
		}

		public void DeleteArticle(Article a)
		{
			ArticleService service = new ArticleService();
			service.DeleteArticle(a);
		}

		public void UpdateArticle(Article aModif)
		{
			ArticleService service = new ArticleService();
			service.UpdateArticle(aModif);
		}
	}
}
