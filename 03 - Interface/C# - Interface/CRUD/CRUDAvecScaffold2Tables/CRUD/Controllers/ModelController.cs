using CRUD.Helpers;
using CRUD.Models.Data;
using CRUD.Models.Dtos;
using CRUD.Models.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CRUD.Models.Profiles;
using CRUD.Models;
using System.Collections.Generic;

namespace CRUD.Controllers
{
	public class ModeleController : ControllerBase
	{
		private readonly ModelService _service;
		private readonly IMapper _mapper;

		public ModeleController(voitureDBContext context)
		{
			_service = new ModelService(context);
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<ModelProfile>();
			});
			_mapper = config.CreateMapper();
		}

		public IEnumerable<ModelDtoAvecMarque> GetAllMarques()
		{
			IEnumerable<Modele> liste = _service.GetAllModels();
			return _mapper.Map<IEnumerable<ModelDtoAvecMarque>>(liste);
		}

		public ActionResult<ModelDtoAvecMarque> GetModeleById(int id)
		{
			Modele commandItem = _service.GetModelById(id);
			if (commandItem != null)
			{
				return Ok(_mapper.Map<ModelDtoAvecMarque>(commandItem));
			}
			return NotFound();
		}

		public ActionResult<ModelDtoSansMarque> CreateModele(ModelDtoSansMarque obj)
		{
			Modele newModele = _mapper.Map<Modele>(obj);
			_service.AddModel(newModele);
			return CreatedAtRoute(nameof(GetModeleById), new { Id = newModele.IdModele }, newModele);
		}

		public ActionResult UpdateModele(int id, ModelDtoSansMarque obj)
		{
			Modele objFromRepo = _service.GetModelById(id);
			if (objFromRepo == null)
			{
				return NotFound();
			}
			objFromRepo.Dump();
			_mapper.Map(obj, objFromRepo);
			objFromRepo.Dump();
			// inutile puisque la fonction ne fait rien, mais garde la cohérence
			_service.UpdateModel(objFromRepo);
			return NoContent();
		}

		public ActionResult DeleteModele(int id)
		{
			Modele obj = _service.GetModelById(id);
			if (obj == null)
			{
				return NotFound();
			}
			_service.DeleteModel(obj);
			return NoContent();
		}
	}
}