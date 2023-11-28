using Api.Helpers;
using Api.Models.Data;
using Api.Models.Data.DTO;
using Api.Models.Data.Services;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Adapters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.Controllers
{
	[Route("api/[Controller]")]
	[ApiController]
	public class PersonnesController : ControllerBase
	{
		private readonly PersonnesServices _service;
		private readonly IMapper _mapper;

		public PersonnesController(PersonnesServices service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		// GET api/personnes
		[HttpGet]
		public ActionResult<IEnumerable<PersonnesDTO>> GetAllPersonne()
		{
			var listePersonnes = _service.GetAllPersonnes();
			return Ok(_mapper.Map<IEnumerable<PersonnesDTO>>(listePersonnes));
		}

		// GET  api/personnes/{id}
		[HttpGet("{id}", Name = "GetPersonneById")]
		public ActionResult<PersonnesDTO> GetPersonneById(int id)
		{
			var commandItem = _service.GetPersonneById(id);
			if (commandItem != null)
			{
				return Ok(_mapper.Map<PersonnesDTO>(commandItem));
			}
			return NotFound();
		}

		// POST api/Personnes
		[HttpPost]
		public ActionResult<PersonnesDTO> CreatePersonne(Personne personne)
		{
			//on ajoute l’objet à la base de données
			_service.AddPersonnes(personne);
			//on retourne le chemin de findById avec l'objet créé
			return CreatedAtRoute(nameof(GetPersonneById), new { personne.Id }, personne);
		}

		// PUT api/personnes/{id}
		[HttpPut("{id}")]
		public ActionResult UpdatePersonne(int id, PersonnesDTO personne)
		{
			var personneFromRepo = _service.GetPersonneById(id);
			if (personneFromRepo == null)
			{
				return NotFound();
			}
			personneFromRepo.Dump();
			_mapper.Map(personne, personneFromRepo);
			personneFromRepo.Dump();

			_service.UpdatePersonne(personneFromRepo);

			return NoContent();
		}

		// PATCH api/personnes/{id}
		[HttpPatch("{id}")]
		public ActionResult PartialPersonneUpdate(int id, JsonPatchDocument<Personne> patchDoc)
		{
			var personneFromRepo = _service.GetPersonneById(id);
			if (personneFromRepo == null)
			{
				return NotFound();
			}

			var personneToPatch = _mapper.Map<Personne>(personneFromRepo);

			patchDoc.ApplyTo(personneFromRepo, ModelState);

			if (!TryValidateModel(personneToPatch))
			{
				return ValidationProblem(ModelState);
			}
			personneFromRepo.Dump();
			_mapper.Map(personneToPatch, personneFromRepo);
			personneFromRepo.Dump();
			_service.UpdatePersonne(personneFromRepo);

			return NoContent();
		}

		// DELETE api/personnes/{id}
		[HttpDelete("{id}")]
		public ActionResult DeletePersonne(int id)
		{
			var personneModelFromRepo = _service.GetPersonneById(id);
			if (personneModelFromRepo == null)
			{
				return NotFound();
			}

			_service.DeletePersonne(personneModelFromRepo);
			return NoContent();
		}
	}
}
