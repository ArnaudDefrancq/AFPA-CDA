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

		public List<ArticleDto> GetAllArticles()
		{
			ArticleProfile profile = new ArticleProfile();
			List<ArticleDto> articleDtos = profile.ArticlesToArticleDto();
			return articleDtos;

		}

		public void CreateArticle(Article a)
		{
			ArticleService service = new ArticleService();
			service.AddArticle(a);
		}

		public void DeleteArticle(ArticleDto aDto)
		{
			ArticleProfile profile = new ArticleProfile();
			Article a = profile.ArticleDtoToArticle(aDto);

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
