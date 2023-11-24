using Api.Models.Data;
using Api.Models.Data.DTO;
using Api.Models.Data.Services;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

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
		[HttpGet("{id}", Name = "GetPersonnesById")]
		public ActionResult<PersonnesDTO> GetPersonneById(int id)
		{
			var commandItem = _service.GetPersonneById(id);
			if (commandItem != null)
			{
				return Ok(_mapper.Map<PersonnesDTO>(commandItem));
			}
			return NotFound();
		}

		// POST api/personnes
		//[HttpPost]
		//public ActionResult<PersonnesDTO> CreatePersonne(Personne personne)
		//{
		//	_service.AddPersonnes(personne);
		//	return CreatedAtRoute(nameof(GetPersonneById), new { personne.Id }, personne);
		//}
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
		//[HttpPatch("{id}")]
		//public ActionResult PartialPersonneUpdate(int id, JsonPatchDocument<Personne>patchDoc)
		//{ }
	}
}
