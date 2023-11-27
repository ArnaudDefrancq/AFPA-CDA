using Api.Helpers;
using Api.Models.Data;
using Api.Models.Data.Services;
using Api.Models.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[Route("api/[Controller]")]
	[ApiController]


	public class VoituresController : ControllerBase
	{
		private readonly VoituresService _service;
		private readonly IMapper _mapper;

		public VoituresController(VoituresService service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		// GET api/personnes
		[HttpGet]
		public ActionResult<IEnumerable<VoituresDto>> GetAllVoitures()
		{
			var listeVoitures = _service.GetAllVoitures();
			return Ok(_mapper.Map<IEnumerable<VoituresDto>>(listeVoitures));
		}

		// GET  api/personnes/{id}
		[HttpGet("{id}", Name = "GetVoitureById")]
		public ActionResult<VoituresDto> GetVoitureById(int id)
		{
			var item = _service.GetVoitureById(id);
			if (item != null)
			{
				return Ok(_mapper.Map<VoituresDto>(item));
			}
			return NotFound();
		}

		// POST api/Personnes
		[HttpPost]
		public ActionResult<VoituresDto> CreateVoiture(Voiture v)
		{
			//on ajoute l’objet à la base de données
			_service.AddVoitures(v);
			//on retourne le chemin de findById avec l'objet créé
			return CreatedAtRoute(nameof(GetVoitureById), new { Id = v.IdVoiture }, v);
		}

		// PUT api/personnes/{id}
		[HttpPut("{id}")]
		public ActionResult UpdateVoiture(int id, VoituresDto v)
		{
			var voitureFromRepo = _service.GetVoitureById(id);
			if (voitureFromRepo == null)
			{
				return NotFound();
			}
			voitureFromRepo.Dump();
			_mapper.Map(v, voitureFromRepo);
			voitureFromRepo.Dump();

			_service.UpdateVoiture(voitureFromRepo);

			return NoContent();
		}

		// PATCH api/personnes/{id}
		[HttpPatch("{id}")]
		public ActionResult PartialPersonneUpdate(int id, JsonPatchDocument<Voiture>
			patchDoc)
		{
			var voitureFromRepo = _service.GetVoitureById(id);
			if (voitureFromRepo == null)
			{
				return NotFound();
			}

			var voitureToPatch = _mapper.Map<Voiture>(voitureFromRepo);

			patchDoc.ApplyTo(voitureFromRepo, ModelState);

			if (!TryValidateModel(voitureToPatch))
			{
				return ValidationProblem(ModelState);
			}
			voitureFromRepo.Dump();
			_mapper.Map(voitureToPatch, voitureFromRepo);
			voitureFromRepo.Dump();
			_service.UpdateVoiture(voitureFromRepo);

			return NoContent();
		}

		// DELETE api/personnes/{id}
		[HttpDelete("{id}")]
		public ActionResult DeleteVoiture(int id)
		{
			var voitureModelFromRepo = _service.GetVoitureById(id);
			if (voitureModelFromRepo == null)
			{
				return NotFound();
			}

			_service.DeleteVoiture(voitureModelFromRepo);
			return NoContent();

		}
	}


}
