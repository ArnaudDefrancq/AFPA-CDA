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
	public class EtudiantController : ControllerBase
	{
		private readonly EtudiantService _service;
		private readonly IMapper _mapper;

		public EtudiantController(GestionCoursDBContext context)
		{
			_service = new EtudiantService(context);
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<EtudiantProfile>();
				cfg.AddProfile<CoursProfile>();
				cfg.AddProfile<InscriptionProfile>();
			});
			_mapper = config.CreateMapper();
		}


		public IEnumerable<EtudiantDtoOutAplatie> GetAllEtudiants()
		{
			IEnumerable<Etudiant> liste = _service.GetAllEtudiants();
			return _mapper.Map<IEnumerable<EtudiantDtoOutAplatie>>(liste);
		}


		public ActionResult<Etudiant> GetEtudiantById(int id)
		{
			Etudiant item = _service.GetEtudiantById(id);
			if (item != null)
			{
				return Ok(_mapper.Map<Etudiant>(item));
			}
			return NotFound();
		}


		public ActionResult<Etudiant> CreateEtudiant(EtudiantDtoIn obj)
		{
			Etudiant newItem = _mapper.Map<Etudiant>(obj);
			_service.AddEtudiant(newItem);
			return CreatedAtRoute(nameof(GetEtudiantById), new { Id = newItem.IdEtudiants }, newItem);
		}

		public ActionResult UpdateEtudiant(int id, EtudiantDtoIn obj)
		{
			Etudiant objFromRepo = _service.GetEtudiantById(id);
			if (objFromRepo == null)
			{
				return NotFound();
			}
			_mapper.Map(obj, objFromRepo);
			// inutile puisque la fonction ne fait rien, mais garde la cohérence
			_service.UpdateEtudiant(objFromRepo);
			return NoContent();
		}

		public ActionResult DeleteEtudiant(int id)
		{
			Etudiant obj = _service.GetEtudiantById(id);
			if (obj == null)
			{
				return NotFound();
			}
			_service.DeleteEtudiant(obj);
			return NoContent();
		}
	}
}
