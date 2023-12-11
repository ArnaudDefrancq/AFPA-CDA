using AutoMapper;
using CRUD.Models.Data;
using CRUD.Models.Dtos;
using CRUD.Models.Services;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.Models.Profiles;

namespace CRUD.Controllers
{
	public class MedicamentController : ControllerBase
	{
		private readonly MedicamentService _service;
		private readonly IMapper _mapper;

		public MedicamentController(medecinedbDBContext context)
		{
			_service = new MedicamentService(context);
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<MedicamentProfile>();
			});
			_mapper = config.CreateMapper();
		}


		public IEnumerable<MedicamentDtoSansPrescription> GetAllMedicaments()
		{
			IEnumerable<Medicament> liste = _service.GetAllMedicaments();
			return _mapper.Map<IEnumerable<MedicamentDtoSansPrescription>>(liste);
		}


		public ActionResult<Medicament> GetMedicamentById(int id)
		{
			Medicament item = _service.GetMedicamentById(id);
			if (item != null)
			{
				return Ok(_mapper.Map<Medicament>(item));
			}
			return NotFound();
		}


		public ActionResult<Medicament> CreateMedicament(MedicamentDtoSansPrescription obj)
		{
			Medicament item = _mapper.Map<Medicament>(obj);
			_service.AddMedicament(item);
			return CreatedAtRoute(nameof(GetMedicamentById), new { Id = item.IdMedicament }, item);
		}

		public ActionResult UpdateMedicament(int id, MedicamentDtoSansPrescription obj)
		{
			Medicament objFromRepo = _service.GetMedicamentById(id);
			if (objFromRepo == null)
			{
				return NotFound();
			}
			_mapper.Map(obj, objFromRepo);
			// inutile puisque la fonction ne fait rien, mais garde la cohérence
			_service.UpdateMedicament(objFromRepo);
			return NoContent();
		}

		public ActionResult DeleteMedicament(int id)
		{
			Medicament obj = _service.GetMedicamentById(id);
			if (obj == null)
			{
				return NotFound();
			}
			_service.DeleteMedicament(obj);
			return NoContent();
		}
	}
}
