using AutoMapper;
using gestionStock.Models.Data;
using gestionStock.Models.Dtos;
using gestionStock.Models.Services;
using gestionStock.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using gestionStock.Models.Profiles;

namespace gestionStock.Controllers
{
	public class CategorieController : ControllerBase
	{
		private readonly CategorieService _service;
		private readonly IMapper _mapper;

		public CategorieController(GestionStocksDBContext context)
		{
			_service = new CategorieService(context);
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<CategorieProfile>();
			});
			_mapper = config.CreateMapper();
		}


		public IEnumerable<CategorieDtoAplatie> GetAllCategories()
		{
			IEnumerable<Categorie> liste = _service.GetAllCategories();
			return _mapper.Map<IEnumerable<CategorieDtoAplatie>>(liste);
		}


		public ActionResult<Categorie> GetCategorieById(int id)
		{
			Categorie item = _service.GetCategorieById(id);
			if (item != null)
			{
				return Ok(_mapper.Map<Categorie>(item));
			}
			return NotFound();
		}


		public ActionResult<Categorie> CreateCategorie(CategorieDtoIn obj)
		{
			Categorie newItem = _mapper.Map<Categorie>(obj);
			_service.AddCategory(newItem);
			return CreatedAtRoute(nameof(GetCategorieById), new { Id = newItem.IdCategorie }, newItem);
		}

		public ActionResult UpdateCategorie(int id, CategorieDtoIn obj)
		{
			Categorie objFromRepo = _service.GetCategorieById(id);
			if (objFromRepo == null)
			{
				return NotFound();
			}
			_mapper.Map(obj, objFromRepo);
			// inutile puisque la fonction ne fait rien, mais garde la cohérence
			_service.UpdateCategorie(objFromRepo);
			return NoContent();
		}

		public ActionResult DeleteCategorie(int id)
		{
			Categorie obj = _service.GetCategorieById(id);
			if (obj == null)
			{
				return NotFound();
			}
			_service.DeleteCategorie(obj);
			return NoContent();
		}
	}
}
