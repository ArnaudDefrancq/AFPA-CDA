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
	public class PrescriptionController : ControllerBase
	{
		private readonly PrescriptionService _service;
		private readonly IMapper _mapper;

		public PrescriptionController(medecinedbDBContext context)
		{
			_service = new PrescriptionService(context);
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<MedicamentProfile>();
			});
			_mapper = config.CreateMapper();
		}


		public IEnumerable<PrescriptionDtoOutAplatie> GetAllPrescriptions()
		{
			IEnumerable<Prescription> liste = _service.GetAllPrescriptions();
			return _mapper.Map<IEnumerable<PrescriptionDtoOutAplatie>>(liste);
		}


		public ActionResult<Prescription> GetPrescriptionById(int id)
		{
			Prescription item = _service.GetPrescriptionById(id);
			if (item != null)
			{
				return Ok(_mapper.Map<Prescription>(item));
			}
			return NotFound();
		}


		public ActionResult<Prescription> CreatePrescription(PrescriptionDtoIn obj)
		{
			Prescription item = _mapper.Map<Prescription>(obj);
			_service.AddPrescription(item);
			return CreatedAtRoute(nameof(GetPrescriptionById), new { Id = item.IdPrescription }, item);
		}

		public ActionResult UpdatePrescription(int id, PrescriptionDtoIn obj)
		{
			Prescription objFromRepo = _service.GetPrescriptionById(id);
			if (objFromRepo == null)
			{
				return NotFound();
			}
			_mapper.Map(obj, objFromRepo);
			// inutile puisque la fonction ne fait rien, mais garde la cohérence
			_service.UpdatePrescription(objFromRepo);
			return NoContent();
		}

		public ActionResult DeletePrescription(int id)
		{
			Prescription obj = _service.GetPrescriptionById(id);
			if (obj == null)
			{
				return NotFound();
			}
			_service.DeletePrescription(obj);
			return NoContent();
		}
	}
}
