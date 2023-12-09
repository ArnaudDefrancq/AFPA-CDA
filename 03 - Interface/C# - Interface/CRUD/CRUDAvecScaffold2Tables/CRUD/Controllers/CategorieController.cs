using AutoMapper;
using CRUD.Models;
using CRUD.Models.Data;
using CRUD.Models.Dtos;
using CRUD.Models.Profiles;
using CRUD.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
	public class CategorieController : ControllerBase
	{
		private readonly CategorieService _service;
		private readonly IMapper _mapper;

		public CategorieController(ImmobilierDBContext context)
		{
			_service = new ImmobilierDBContext(context);
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<CategorieProfile>();
			});
			_mapper = config.CreateMapper();
		}


		public IEnumerable<CategorieDtoOut> GetAllCategories()
		{
			IEnumerable<Categorie> liste = _service.GetAllCategories();
			return _mapper.Map<IEnumerable<CategorieDtoOut>>(liste);
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
			_service.AddCategorie(newItem);
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
