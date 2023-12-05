using CRUD.Models.Data;
using CRUD.Models.Dtos;
using CRUD.Models.Profiles;
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
			//ArticleProfile profile = new ArticleProfile();
			//List<ArticleDto> articleDtos = profile.ListArticlesDto();
			//return articleDtos;
			ArticleService service = new ArticleService();
			return service.GetAllArticles();

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
