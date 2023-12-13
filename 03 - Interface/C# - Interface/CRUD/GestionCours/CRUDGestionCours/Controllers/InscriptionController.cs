using AutoMapper;
using CRUDGestionCours.Models.Data;
using CRUDGestionCours.Models.Dtos;
using CRUDGestionCours.Models.Services;
using CRUDGestionCours.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CRUDGestionCours.Models.Profiles;

namespace CRUDGestionCours.Controllers
{
	public class InscriptionController : ControllerBase
	{
		private readonly InscriptionService _service;
		private readonly IMapper _mapper;

		public InscriptionController(GestionCoursDBContext context)
		{
			_service = new InscriptionService(context);
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<InscriptionProfile>();
				cfg.AddProfile<CoursProfile>();
				cfg.AddProfile<EtudiantProfile>();
			});
			_mapper = config.CreateMapper();
		}


		public IEnumerable<InscriptionDtoOutAplatie> GetAllInscriptions()
		{
			IEnumerable<Inscription> liste = _service.GetAllInscriptions();
			return _mapper.Map<IEnumerable<InscriptionDtoOutAplatie>>(liste);
		}


		public ActionResult<Inscription> GetInscriptionById(int id)
		{
			Inscription item = _service.GetInscriptionById(id);
			if (item != null)
			{
				return Ok(_mapper.Map<Inscription>(item));
			}
			return NotFound();
		}


		public ActionResult<Inscription> CreateInscription(InscriptionDtoIn obj)
		{
			Inscription newItem = _mapper.Map<Inscription>(obj);
			_service.AddInscription(newItem);
			return CreatedAtRoute(nameof(GetInscriptionById), new { Id = newItem.IdInscriptions }, newItem);
		}

		public ActionResult UpdateInscription(int id, InscriptionDtoIn obj)
		{
			Inscription objFromRepo = _service.GetInscriptionById(id);
			if (objFromRepo == null)
			{
				return NotFound();
			}
			_mapper.Map(obj, objFromRepo);
			// inutile puisque la fonction ne fait rien, mais garde la cohérence
			_service.UpdateInscription(objFromRepo);
			return NoContent();
		}

		public ActionResult DeleteInscription(int id)
		{
			Inscription obj = _service.GetInscriptionById(id);
			if (obj == null)
			{
				return NotFound();
			}
			_service.DeleteInscription(obj);
			return NoContent();
		}
	}
}
