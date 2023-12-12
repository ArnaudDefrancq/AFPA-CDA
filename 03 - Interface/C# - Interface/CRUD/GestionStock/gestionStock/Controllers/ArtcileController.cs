using AutoMapper;
using gestionStock.Models;
using gestionStock.Models.Data;
using gestionStock.Models.Dtos;
using gestionStock.Models.Profiles;
using gestionStock.Models.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace gestionStock.Controllers
{
	public class ArtcileController : ControllerBase
	{
		private readonly ArticleService _service;
		private readonly IMapper _mapper;

		public ArtcileController(GestionStocksDBContext context)
		{
			_service = new ArticleService(context);
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<ArticleProfile>();
			});
			_mapper = config.CreateMapper();
		}


		public IEnumerable<ArticleDtoOutAplatie> GetAllArticles()
		{
			IEnumerable<Article> liste = _service.GetAllArticles();
			return _mapper.Map<IEnumerable<ArticleDtoOutAplatie>>(liste);
		}


		public ActionResult<Article> GetArticleById(int id)
		{
			Article item = _service.GetArticleById(id);
			if (item != null)
			{
				return Ok(_mapper.Map<Article>(item));
			}
			return NotFound();
		}


		public ActionResult<Article> CreateArticle(ArticleDtoIn obj)
		{
			Article newItem = _mapper.Map<Article>(obj);
			_service.AddArticle(newItem);
			return CreatedAtRoute(nameof(GetArticleById), new { Id = newItem.IdArticle }, newItem);
		}

		public ActionResult UpdateArticle(int id, ArticleDtoIn obj)
		{
			Article objFromRepo = _service.GetArticleById(id);
			if (objFromRepo == null)
			{
				return NotFound();
			}
			_mapper.Map(obj, objFromRepo);
			// inutile puisque la fonction ne fait rien, mais garde la cohérence
			_service.UpdateArticle(objFromRepo);
			return NoContent();
		}

		public ActionResult DeleteArticle(int id)
		{
			Article obj = _service.GetArticleById(id);
			if (obj == null)
			{
				return NotFound();
			}
			_service.DeleteArticle(obj);
			return NoContent();
		}
	}
}
