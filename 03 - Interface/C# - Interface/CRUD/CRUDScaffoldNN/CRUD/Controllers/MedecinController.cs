using AutoMapper;
using CRUD.Models;
using CRUD.Models.Data;
using CRUD.Models.Dtos;
using CRUD.Models.Profiles;
using CRUD.Models.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
	public class MedecinController : ControllerBase
	{
		private readonly MedecinService _service;
		private readonly IMapper _mapper;

		public MedecinController(medecinedbDBContext context)
		{
			_service = new MedecinService(context);
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<MedecinProfile>();
			});
			_mapper = config.CreateMapper();
		}


		public IEnumerable<MedecinDtoSansPrescriptions> GetAllMedecins()
		{
			IEnumerable<Medecin> liste = _service.GetAllMedecins();
			return _mapper.Map<IEnumerable<MedecinDtoSansPrescriptions>>(liste);
		}


		public ActionResult<Medecin> GetMedecinById(int id)
		{
			Medecin item = _service.GetMedecinById(id);
			if (item != null)
			{
				return Ok(_mapper.Map<Medecin>(item));
			}
			return NotFound();
		}


		public ActionResult<Medecin> CreateMedecin(MedecinDtoSansPrescriptions obj)
		{
			Medecin item = _mapper.Map<Medecin>(obj);
			_service.AddMedecin(item);
			return CreatedAtRoute(nameof(GetMedecinById), new { Id = item.IdMedecin }, item);
		}

		public ActionResult UpdateMedecin(int id, MedecinDtoSansPrescriptions obj)
		{
			Medecin objFromRepo = _service.GetMedecinById(id);
			if (objFromRepo == null)
			{
				return NotFound();
			}
			_mapper.Map(obj, objFromRepo);
			// inutile puisque la fonction ne fait rien, mais garde la cohérence
			_service.UpdateMedecin(objFromRepo);
			return NoContent();
		}

		public ActionResult DeleteVoiture(int id)
		{
			Medecin obj = _service.GetMedecinById(id);
			if (obj == null)
			{
				return NotFound();
			}
			_service.DeleteMedecin(obj);
			return NoContent();
		}
	}
}
