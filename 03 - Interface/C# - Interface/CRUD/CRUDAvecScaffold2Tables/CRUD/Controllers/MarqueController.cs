using CRUD.Helpers;
using CRUD.Models.Data;
using CRUD.Models.Dtos;
using CRUD.Models.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CRUD.Models;
using CRUD.Models.Profiles;

namespace CRUD.Controllers
{
	public class MarqueController : ControllerBase
	{
		private readonly MarqueService _service;
		private readonly IMapper _mapper;

		public MarqueController(voitureDBContext context)
		{
			_service = new MarqueService(context);
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<MarqueProfile>();
			});
			_mapper = config.CreateMapper();
		}

		public IEnumerable<MarqueDtoAvecModel> GetAllMarques()
		{
			IEnumerable<Marque> listePersonnes = _service.GetAllMarques();
			return _mapper.Map<IEnumerable<MarqueDtoAvecModel>>(listePersonnes);
		}

		public ActionResult<MarqueDtoSansModel> GetMarqueById(int id)
		{
			Marque commandItem = _service.GetMarqueById(id);
			if (commandItem != null)
			{
				return Ok(_mapper.Map<MarqueDtoSansModel>(commandItem));
			}
			return NotFound();
		}

		public ActionResult<MarqueDtoSansModel> CreateMarque(MarqueDtoSansModel obj)
		{
			Marque newMarque = _mapper.Map<Marque>(obj);
			_service.AddMarque(newMarque);
			return CreatedAtRoute(nameof(GetMarqueById), new { Id = newMarque.IdMarque }, newMarque);
		}

		public ActionResult UpdateMarque(int id, MarqueDtoSansModel obj)
		{
			Marque objFromRepo = _service.GetMarqueById(id);
			if (objFromRepo == null)
			{
				return NotFound();
			}
			objFromRepo.Dump();
			_mapper.Map(obj, objFromRepo);
			objFromRepo.Dump();
			// inutile puisque la fonction ne fait rien, mais garde la cohérence
			_service.UpdateMarque(objFromRepo);
			return NoContent();
		}

		public ActionResult DeleteMarque(int id)
		{
			Marque obj = _service.GetMarqueById(id);
			if (obj == null)
			{
				return NotFound();
			}
			_service.DeleteMarque(obj);
			return NoContent();
		}
	}
}