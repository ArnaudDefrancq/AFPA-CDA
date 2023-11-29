using Api.Helpers;
using Api.Models.Data;
using Api.Models.Dtos;
using Api.Models.Services;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	public class CadeauController : ControllerBase
	{
		private readonly CadeauService _service;
		private readonly IMapper _mapper;
		public CadeauController(CadeauService service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		//GET api/Cadeaus
		[HttpGet]
		public ActionResult<IEnumerable<CadeauDto>> getAllCadeaus()
		{
			var listeCadeaus = _service.GetAllCadeaus();
			return Ok(_mapper.Map<IEnumerable<CadeauDto>>(listeCadeaus));
		}

		//GET api/Cadeaus/{id}
		[HttpGet("{id}", Name = "GetCadeauById")]
		public ActionResult<CadeauDto> GetCadeauById(int id)
		{
			var commandItem = _service.GetCadeauById(id);
			if (commandItem != null)
			{
				return Ok(_mapper.Map<CadeauDto>(commandItem));
			}
			return NotFound();
		}

		//POST api/GameConsoles
		[HttpPost]
		public ActionResult<Cadeau> CreateCadeau(CadeauDto varPlaceholderDto)
		{
			Cadeau varPlaceholder = new Cadeau();
			_mapper.Map(varPlaceholderDto, varPlaceholder);
			//on ajoute l’objet à la base de données
			_service.AddCadeaus(varPlaceholder);
			//on retourne le chemin de findById avec l'objet créé
			return CreatedAtRoute(nameof(GetCadeauById), new { Id = varPlaceholder.IdCadeau }, varPlaceholder);
		}

		[HttpPut("{id}")]
		public ActionResult UpdateCadeau(int id, CadeauDto varPlaceholder)
		{
			var varPlaceholderFromRepo = _service.GetCadeauById(id);
			if (varPlaceholderFromRepo == null)
			{
				return NotFound();
			}
			varPlaceholderFromRepo.Dump();
			_mapper.Map(varPlaceholder, varPlaceholderFromRepo);
			varPlaceholderFromRepo.Dump();
			varPlaceholder.Dump();
			// inutile puisque la fonction ne fait rien, mais garde la cohérence
			_service.UpdateCadeau(varPlaceholderFromRepo);
			return NoContent();
		}

		[HttpPatch("{id}")]
		public ActionResult PartialCadeauUpdate(int id, JsonPatchDocument<Cadeau> patchDoc)
		{
			try
			{
				var varPlaceholderFromRepo = _service.GetCadeauById(id);
				varPlaceholderFromRepo.Dump();

				var varPlaceholderToPatch = _mapper.Map<Cadeau>(varPlaceholderFromRepo);

				patchDoc.ApplyTo(varPlaceholderToPatch, ModelState);

				if (!TryValidateModel(varPlaceholderToPatch)) return ValidationProblem(ModelState);
				_mapper.Map(varPlaceholderToPatch, varPlaceholderFromRepo);
				_service.UpdateCadeau(varPlaceholderFromRepo);
				varPlaceholderFromRepo.Dump();
			}
			catch (HttpRequestException error)
			{
				return null;
			}
			catch (Exception)
			{
				return NotFound();
			}
			return NoContent();
		}

		//DELETE api/Cadeaus/{id}
		[HttpDelete("{id}")]
		public ActionResult DeleteCadeau(int id)
		{
			var varPlaceholderModelFromRepo = _service.GetCadeauById(id);
			if (varPlaceholderModelFromRepo == null)
			{
				return NotFound();
			}
			_service.DeleteCadeau(varPlaceholderModelFromRepo);
			return NoContent();
		}
	}

}

