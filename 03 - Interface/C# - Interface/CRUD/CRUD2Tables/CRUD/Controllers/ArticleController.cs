using CRUD.Models.Data;
using CRUD.Models.Dtos;
using CRUD.Models.Profiles;
using CRUD.Models.Services;
using System.Collections.Generic;

namespace CRUD.Controllers
{
	public class ArticleController
	{

		private ArticleService _service;
		private ArticleProfile _profile;

		public ArticleController()
		{
			_service = new ArticleService();
			_profile = new ArticleProfile();
		}

		public List<ArticleDto> GetAllArticles()
		{
			List<ArticleDto> articleDtos = _profile.ArticlesToArticleDto();
			return articleDtos;

		}

		public void CreateArticle(Article a)
		{
			_service.AddArticle(a);
		}

		public void DeleteArticle(ArticleDto aDto)
		{
			Article a = _profile.ArticleDtoToArticle(aDto);
			_service.DeleteArticle(a);
		}

		public void UpdateArticle(Article aModif)
		{
			_service.UpdateArticle(aModif);
		}
	}
}
