using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using NewApi.Helpers;
using NewApi.Models.Data;
using NewApi.Models.Dtos;
using NewApi.Models.Services;

namespace NewApi.Controllers

{
	[Route("api/[Controller]")]
	[ApiController]
	public class EmployeController : ControllerBase
	{
		private readonly EmployesService _service;
		private readonly IMapper _mapper;

		public EmployeController(EmployesService service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		// GET api/Employe
		[HttpGet]
		public ActionResult<IEnumerable<EmployesDto>> GetAllEmployes()
		{
			var listeEmployes = _service.GetAllEmployes();
			return Ok(_mapper.Map<IEnumerable<EmployesDto>>(listeEmployes));
		}

		// GET  api/Employe/{id}
		[HttpGet("{id}", Name = "GetEmployeById")]
		public ActionResult<EmployesDto> GetEmployeById(int id)
		{
			var item = _service.GetEmployeById(id);
			if (item != null)
			{
				return Ok(_mapper.Map<EmployesDto>(item));
			}
			return NotFound();
		}

		// POST api/Employe
		[HttpPost]
		public ActionResult<EmployesDto> CreateEmploye(Employe e)
		{
			//on ajoute l’objet à la base de données
			_service.AddEmploye(e);
			//on retourne le chemin de findById avec l'objet créé
			return CreatedAtRoute(nameof(GetEmployeById), new { Id = e.IdEmploye }, e);
		}

		// PUT api/Employe/{id}
		[HttpPut("{id}")]
		public ActionResult UpdateEmploye(int id, EmployesDto e)
		{
			var employeFromRepo = _service.GetEmployeById(id);
			if (employeFromRepo == null)
			{
				return NotFound();
			}
			employeFromRepo.Dump();
			_mapper.Map(e, employeFromRepo);
			employeFromRepo.Dump();

			_service.UpdateEmploye(employeFromRepo);

			return NoContent();
		}

		// PATCH api/Employe/{id}
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

		// DELETE api/Employe/{id}
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
