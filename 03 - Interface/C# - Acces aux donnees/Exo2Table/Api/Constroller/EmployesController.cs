
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
		public ActionResult<IEnumerable<EmployeDTO>> GetAllEmploye()
		{
			var listePersonnes = _service.GetAllEmployes();
			return Ok(_mapper.Map<IEnumerable<EmployeDTO>
				>(listePersonnes));
		}

		// GET  api/personnes/{id}
		[HttpGet("{id}", Name = "GetEmployeById")]
		public ActionResult<EmployeDTO> GetEmployeById(int id)
		{
			var commandItem = _service.GetEmployeById(id);
			if (commandItem != null)
			{
				return Ok(_mapper.Map<EmployeDTO>
					(commandItem));
			}
			return NotFound();
		}

		// POST api/Personnes
		[HttpPost]
		public ActionResult<EmployeDTO> CreatePersonne(Employe employe)
		{
			//on ajoute l’objet à la base de données
			_service.AddEmployes(employe);
			//on retourne le chemin de findById avec l'objet créé
			return CreatedAtRoute(nameof(GetEmployeById), new { employe.IdEmploye }, employe);
		}

		// PUT api/personnes/{id}
		[HttpPut("{id}")]
		public ActionResult UpdateEmploye(int id, EmployeDTO employe)
		{
			var employeFromRepo = _service.GetEmployeById(id);
			if (employeFromRepo == null)
			{
				return NotFound();
			}
			employeFromRepo.Dump();
			_mapper.Map(employe, employeFromRepo);
			employeFromRepo.Dump();

			_service.UpdateEmploye(employeFromRepo);

			return NoContent();
		}

		// PATCH api/personnes/{id}
		[HttpPatch("{id}")]
		public ActionResult PartialEmployeUpdate(int id, JsonPatchDocument<Employe>
			patchDoc)
		{
			var employeFromRepo = _service.GetEmployeById(id);
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
			_service.UpdateEmploye(employeFromRepo);

			return NoContent();
		}

		// DELETE api/personnes/{id}
		[HttpDelete("{id}")]
		public ActionResult DeleteEmploye(int id)
		{
			var employeModelFromRepo = _service.GetEmployeById(id);
			if (employeModelFromRepo == null)
			{
				return NotFound();
			}

			_service.DeleteEmploye(employeModelFromRepo);
			return NoContent();
		}
	}
}

