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

		public List<Article> GetAllProduits()
		{
			ArticleService service = new ArticleService();
			List<Article> produits = service.GetAllArticles();
			return produits;
		}

		public void CreateProduit(Article a)
		{
			ArticleService service = new ArticleService();
			service.AddArticle(a);
		}

		public void DeleteProduit(Article a)
		{
			ArticleService service = new ArticleService();
			service.DeleteArticle(a);
		}

		public void UpdateProduit(Article aModif)
		{
			ArticleService service = new ArticleService();
			service.UpdateArticle(aModif);
		}
	}
}
