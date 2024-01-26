using AutoMapper;
using CRUDGestionCours.Models;
using CRUDGestionCours.Models.Data;
using CRUDGestionCours.Models.Dtos;
using CRUDGestionCours.Models.Profiles;
using CRUDGestionCours.Models.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CRUDGestionCours.Controllers
{
	public class CoursController : ControllerBase
	{
		private readonly CoursService _service;
		private readonly IMapper _mapper;

		public CoursController(GestionCoursDBContext context)
		{
			_service = new CoursService(context);
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<CoursProfile>();
				cfg.AddProfile<EtudiantProfile>();
				cfg.AddProfile<InscriptionProfile>();
			});
			_mapper = config.CreateMapper();
		}


		public IEnumerable<CoursDtoOutAplatie> GetAllCours()
		{
			IEnumerable<Cour> liste = _service.GetAllCours();
			return _mapper.Map<IEnumerable<CoursDtoOutAplatie>>(liste);
		}


		public ActionResult<Cour> GetCoursById(int id)
		{
			Cour item = _service.GetCoursById(id);
			if (item != null)
			{
				return Ok(_mapper.Map<Cour>(item));
			}
			return NotFound();
		}


		public ActionResult<Cour> CreateCours(CoursDtoIn obj)
		{
			Cour newItem = _mapper.Map<Cour>(obj);
			_service.AddCours(newItem);
			return CreatedAtRoute(nameof(GetCoursById), new { Id = newItem.IdCours }, newItem);
		}

		public ActionResult UpdateCours(int id, CoursDtoIn obj)
		{
			Cour objFromRepo = _service.GetCoursById(id);
			if (objFromRepo == null)
			{
				return NotFound();
			}
			_mapper.Map(obj, objFromRepo);
			// inutile puisque la fonction ne fait rien, mais garde la cohérence
			_service.UpdateCours(objFromRepo);
			return NoContent();
		}

		public ActionResult DeleteCours(int id)
		{
			Cour obj = _service.GetCoursById(id);
			if (obj == null)
			{
				return NotFound();
			}
			_service.DeleteCours(obj);
			return NoContent();
		}
	}
}
