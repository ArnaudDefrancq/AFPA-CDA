using CRUDOpt.Models.Dtos;
using CRUDOpt.Models.Profiles;
using System.Collections.Generic;


namespace CRUDOpt.Controllers
{
	public class ArticleController
	{
		static public List<ArticleDto> GetAllArticles()
		{
			List<ArticleDto> articleDtos = ClassProfiles.FromArticleToArticleDto();
			return articleDtos;

		}
	}
}
