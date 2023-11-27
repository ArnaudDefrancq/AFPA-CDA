using Api.Data;
using Api.Data.DTO;
using Api.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Adapters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.Controllers
{
	[Route("api/[Controller]")]
	[ApiController]
	public class VoitureFonctionsController : ControllerBase
	{
		private readonly VoitureFonctionServices _service;
		private readonly IMapper _mapper;

		public VoitureFonctionsController(VoitureFonctionServices service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		// GET api/personnes
		[HttpGet]
		public ActionResult<IEnumerable<VoitureFonctionDTO>
			> GetAllPersonne()
		{
			var listePersonnes = _service.GetAllPersonnes();
			return Ok(_mapper.Map<IEnumerable<VoitureFonctionDTO>
				>(listePersonnes));
		}

		// GET  api/personnes/{id}
		[HttpGet("{id}", Name = "GetPersonneById")]
		public ActionResult<VoitureFonctionDTO>
			GetPersonneById(int id)
		{
			var commandItem = _service.GetPersonneById(id);
			if (commandItem != null)
			{
				return Ok(_mapper.Map<VoitureFonctionDTO>
					(commandItem));
			}
			return NotFound();
		}

		// POST api/Personnes
		[HttpPost]
		public ActionResult<VoitureFonctionDTO>
			CreatePersonne(Voiturefonction voiture)
		{
			//on ajoute l’objet à la base de données
			_service.AddPersonnes(voiture);
			//on retourne le chemin de findById avec l'objet créé
			return CreatedAtRoute(nameof(GetPersonneById), new { voiture.IdVoitureFonction }, voiture);
		}

		// PUT api/personnes/{id}
		[HttpPut("{id}")]
		public ActionResult UpdatePersonne(int id, VoitureFonctionDTO voiture)
		{
			var voitureFromRepo = _service.GetPersonneById(id);
			if (voitureFromRepo == null)
			{
				return NotFound();
			}
			voitureFromRepo.Dump();
			_mapper.Map(voiture, voitureFromRepo);
			voitureFromRepo.Dump();

			_service.UpdatePersonne(voitureFromRepo);

			return NoContent();
		}

		// PATCH api/personnes/{id}
		[HttpPatch("{id}")]
		public ActionResult PartialPersonneUpdate(int id, JsonPatchDocument<Voiturefonction>
			patchDoc)
		{
			var voitureFromRepo = _service.GetPersonneById(id);
			if (voitureFromRepo == null)
			{
				return NotFound();
			}

			var voitureToPatch = _mapper.Map<Voiturefonction>(voitureFromRepo);

			patchDoc.ApplyTo(voitureFromRepo, ModelState);

			if (!TryValidateModel(voitureToPatch))
			{
				return ValidationProblem(ModelState);
			}
			voitureFromRepo.Dump();
			_mapper.Map(voitureToPatch, voitureFromRepo);
			voitureFromRepo.Dump();
			_service.UpdatePersonne(voitureFromRepo);

			return NoContent();
		}

		// DELETE api/personnes/{id}
		[HttpDelete("{id}")]
		public ActionResult DeletePersonne(int id)
		{
			var voitureModelFromRepo = _service.GetPersonneById(id);
			if (voitureModelFromRepo == null)
			{
				return NotFound();
			}

			_service.DeletePersonne(voitureModelFromRepo);
			return NoContent();
		}
	}
}
