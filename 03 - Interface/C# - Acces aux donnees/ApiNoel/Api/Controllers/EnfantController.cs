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
	public class EnfantsController : ControllerBase
	{
		private readonly EnfantService _service;
		private readonly IMapper _mapper;
		public EnfantsController(EnfantService service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		//GET api/Enfants
		[HttpGet]
		public ActionResult<IEnumerable<EnfantDto>> getAllEnfants()
		{
			var listeEnfants = _service.GetAllEnfants();
			return Ok(_mapper.Map<IEnumerable<EnfantDto>>(listeEnfants));
		}

		//GET api/Enfants/{id}
		[HttpGet("{id}", Name = "GetEnfantById")]
		public ActionResult<EnfantDto> GetEnfantById(int id)
		{
			var commandItem = _service.GetEnfantById(id);
			if (commandItem != null)
			{
				return Ok(_mapper.Map<EnfantDto>(commandItem));
			}
			return NotFound();
		}

		//POST api/GameConsoles
		[HttpPost]
		public ActionResult<Enfant> CreateEnfant(EnfantDto varPlaceholderDto)
		{
			Enfant varPlaceholder = new Enfant();
			_mapper.Map(varPlaceholderDto, varPlaceholder);
			//on ajoute l’objet à la base de données
			_service.AddEnfants(varPlaceholder);
			//on retourne le chemin de findById avec l'objet créé
			return CreatedAtRoute(nameof(GetEnfantById), new { Id = varPlaceholder.IdEnfant }, varPlaceholder);
		}

		[HttpPut("{id}")]
		public ActionResult UpdateEnfant(int id, EnfantDto varPlaceholder)
		{
			var varPlaceholderFromRepo = _service.GetEnfantById(id);
			if (varPlaceholderFromRepo == null)
			{
				return NotFound();
			}
			varPlaceholderFromRepo.Dump();
			_mapper.Map(varPlaceholder, varPlaceholderFromRepo);
			varPlaceholderFromRepo.Dump();
			varPlaceholder.Dump();
			// inutile puisque la fonction ne fait rien, mais garde la cohérence
			_service.UpdateEnfant(varPlaceholderFromRepo);
			return NoContent();
		}

		[HttpPatch("{id}")]
		public ActionResult PartialEnfantUpdate(int id, JsonPatchDocument<Enfant> patchDoc)
		{
			try
			{
				var varPlaceholderFromRepo = _service.GetEnfantById(id);
				varPlaceholderFromRepo.Dump();

				var varPlaceholderToPatch = _mapper.Map<Enfant>(varPlaceholderFromRepo);

				patchDoc.ApplyTo(varPlaceholderToPatch, ModelState);

				if (!TryValidateModel(varPlaceholderToPatch)) return ValidationProblem(ModelState);
				_mapper.Map(varPlaceholderToPatch, varPlaceholderFromRepo);
				_service.UpdateEnfant(varPlaceholderFromRepo);
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

		//DELETE api/Enfants/{id}
		[HttpDelete("{id}")]
		public ActionResult DeleteEnfant(int id)
		{
			var varPlaceholderModelFromRepo = _service.GetEnfantById(id);
			if (varPlaceholderModelFromRepo == null)
			{
				return NotFound();
			}
			_service.DeleteEnfant(varPlaceholderModelFromRepo);
			return NoContent();
		}
	}

}

