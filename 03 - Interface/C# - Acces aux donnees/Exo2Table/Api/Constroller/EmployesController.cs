
using Api.Data.DTO;
using Api.Data.Models;
using Api.Data.Service;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Adapters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.Controllers
{
	[Route("api/[Controller]")]
	[ApiController]
	public class EmployesController : ControllerBase
	{
		private readonly EmployeServices _service;
		private readonly IMapper _mapper;

		public EmployesController(EmployeServices service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		// GET api/personnes
		[HttpGet]
		public ActionResult<IEnumerable<EmployeDTO>
			> GetAllPersonne()
		{
			var listePersonnes = _service.GetAllPersonnes();
			return Ok(_mapper.Map<IEnumerable<EmployeDTO>
				>(listePersonnes));
		}

		// GET  api/personnes/{id}
		[HttpGet("{id}", Name = "GetPersonneById")]
		public ActionResult<EmployeDTO>
			GetPersonneById(int id)
		{
			var commandItem = _service.GetPersonneById(id);
			if (commandItem != null)
			{
				return Ok(_mapper.Map<EmployeDTO>
					(commandItem));
			}
			return NotFound();
		}

		// POST api/Personnes
		[HttpPost]
		public ActionResult<EmployeDTO>
			CreatePersonne(Employe employe)
		{
			//on ajoute l’objet à la base de données
			_service.AddPersonnes(employe);
			//on retourne le chemin de findById avec l'objet créé
			return CreatedAtRoute(nameof(GetPersonneById), new { employe.IdEmploye }, employe);
		}

		// PUT api/personnes/{id}
		[HttpPut("{id}")]
		public ActionResult UpdatePersonne(int id, EmployeDTO employe)
		{
			var employeFromRepo = _service.GetPersonneById(id);
			if (employeFromRepo == null)
			{
				return NotFound();
			}
			employeFromRepo.Dump();
			_mapper.Map(employe, employeFromRepo);
			employeFromRepo.Dump();

			_service.UpdatePersonne(employeFromRepo);

			return NoContent();
		}

		// PATCH api/personnes/{id}
		[HttpPatch("{id}")]
		public ActionResult PartialPersonneUpdate(int id, JsonPatchDocument<Employe>
			patchDoc)
		{
			var employeFromRepo = _service.GetPersonneById(id);
			if (employeFromRepo == null)
			{
				return NotFound();
			}

			var employeToPatch = _mapper.Map<Employe>(employeFromRepo);

			patchDoc.ApplyTo(employeFromRepo, ModelState);

			if (!TryValidateModel(employeToPatch))
			{
				return ValidationProblem(ModelState);
			}
			employeFromRepo.Dump();
			_mapper.Map(employeToPatch, employeFromRepo);
			employeFromRepo.Dump();
			_service.UpdatePersonne(employeFromRepo);

			return NoContent();
		}

		// DELETE api/personnes/{id}
		[HttpDelete("{id}")]
		public ActionResult DeletePersonne(int id)
		{
			var employeModelFromRepo = _service.GetPersonneById(id);
			if (employeModelFromRepo == null)
			{
				return NotFound();
			}

			_service.DeletePersonne(employeModelFromRepo);
			return NoContent();
		}
	}
}

