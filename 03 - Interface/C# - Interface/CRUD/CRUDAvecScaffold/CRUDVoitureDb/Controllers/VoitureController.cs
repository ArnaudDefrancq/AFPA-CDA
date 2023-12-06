using CRUDVoitureDb.Helpers;
using CRUDVoitureDb.Models.Data;
using CRUDVoitureDb.Models.Dtos;
using CRUDVoitureDb.Models.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CRUDVoitureDb.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VoitureController : ControllerBase
	{
		private readonly VoitureService _service;
		private readonly IMapper _mapper;
		public VoitureController(VoitureService service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		//GET api/Voiture
		[HttpGet]
		public ActionResult<IEnumerable<Voiture>> getAllVoitures()
		{
			IEnumerable<Voiture> listeVoitures = _service.GetAllVoitures();
			return Ok(_mapper.Map<IEnumerable<Voiture>>(listeVoitures));
		}

		//GET api/Voiture/{id}
		[HttpGet("{id}", Name = "GetVoitureById")]
		public ActionResult<Voiture> GetVoitureById(int id)
		{
			Voiture commandItem = _service.GetVoitureById(id);
			if (commandItem != null)
			{
				return Ok(_mapper.Map<Voiture>(commandItem));
			}
			return NotFound();
		}

		//POST api/Voiture
		[HttpPost]
		public ActionResult<Voiture> CreateVoiture(Voiture obj)
		{
			Voiture newVoiture = _mapper.Map<Voiture>(obj);
			_service.AddVoiture(newVoiture);
			return CreatedAtRoute(nameof(GetVoitureById), new { Id = newVoiture.IdVoiture }, newVoiture);
		}

		//PUT api/Voiture/{id}
		[HttpPut("{id}")]
		public ActionResult UpdateVoiture(int id, Voiture obj)
		{
			Voiture objFromRepo = _service.GetVoitureById(id);
			if (objFromRepo == null)
			{
				return NotFound();
			}
			objFromRepo.Dump();
			_mapper.Map(obj, objFromRepo);
			objFromRepo.Dump();
			// inutile puisque la fonction ne fait rien, mais garde la cohérence
			_service.UpdateVoiture(objFromRepo);
			return NoContent();
		}

		// [HttpPatch("{id}")]
		// public ActionResult PartialVoitureUpdate(int id, JsonPatchDocument<Voiture> patchDoc)
		// {
		//		Voiture objFromRepo = _service.GetVoitureById(id);
		//		if (objFromRepo == null)
		//		{
		//			return NotFound();
		//		}
		//		Voiture objToPatch = _mapper.Map<Voiture>(objFromRepo);
		//		patchDoc.ApplyTo(objToPatch, ModelState);
		//		if (!TryValidateModel(objToPatch))
		//		{
		//			return ValidationProblem(ModelState);
		//		}
		//		_mapper.Map(objToPatch, objFromRepo);
		//		_service.UpdateVoiture(objFromRepo);
		//		return NoContent();
		//  }

		// DELETE api/Voiture/{id}
		[HttpDelete("{id}")]
		public ActionResult DeleteVoiture(int id)
		{
			Voiture obj = _service.GetVoitureById(id);
			if (obj == null)
			{
				return NotFound();
			}
			_service.DeleteVoiture(obj);
			return NoContent();
		}
	}
}
