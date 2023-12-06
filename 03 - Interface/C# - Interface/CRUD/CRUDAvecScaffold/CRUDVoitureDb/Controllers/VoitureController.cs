﻿using CRUDVoitureDb.Helpers;
using CRUDVoitureDb.Models.Data;
using CRUDVoitureDb.Models.Dtos;
using CRUDVoitureDb.Models.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CRUDVoitureDb.Models;
using CRUDVoitureDb.Models.Profiles;

namespace CRUDVoitureDb.Controllers
{
	public class VoitureController : ControllerBase
	{
		private readonly VoitureService _service;
		private readonly IMapper _mapper;

		public VoitureController(VoitureDBContext context)
		{
			_service = new VoitureService(context);
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<VoitureProfile>();
			});
			_mapper = config.CreateMapper();
		}


		public ActionResult<IEnumerable<VoitureDto>> GetAllVoitures()
		{
			IEnumerable<Voiture> listeVoitures = _service.GetAllVoitures();
			return Ok(_mapper.Map<IEnumerable<VoitureDto>>(listeVoitures));
		}


		public ActionResult<Voiture> GetVoitureById(int id)
		{
			Voiture commandItem = _service.GetVoitureById(id);
			if (commandItem != null)
			{
				return Ok(_mapper.Map<Voiture>(commandItem));
			}
			return NotFound();
		}


		public ActionResult<Voiture> CreateVoiture(Voiture obj)
		{
			Voiture newVoiture = _mapper.Map<Voiture>(obj);
			_service.AddVoiture(newVoiture);
			return CreatedAtRoute(nameof(GetVoitureById), new { Id = newVoiture.IdVoiture }, newVoiture);
		}

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
