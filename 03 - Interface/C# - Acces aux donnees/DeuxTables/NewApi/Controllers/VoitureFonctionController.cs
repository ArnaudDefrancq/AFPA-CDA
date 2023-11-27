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

	public class VoitureFonctionController : ControllerBase
	{
		private readonly VoitureFonctionsService _service;
		private readonly IMapper _mapper;

		public VoitureFonctionController(VoitureFonctionsService service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		// GET api/VoitureFonction
		[HttpGet]
		public ActionResult<IEnumerable<VoituresFonctionsDto>> GetAllVoitureFonctions()
		{
			var listeVoitureFonction = _service.GetAllVoitureFonctions();
			return Ok(_mapper.Map<IEnumerable<VoituresFonctionsDto>>(listeVoitureFonction));
		}


		// GET  api/VoitureFonction/{id}
		[HttpGet("{id}", Name = "GetVoitureFonctionById")]
		public ActionResult<VoituresFonctionsDto> GetVoitureFonctionById(int id)
		{
			var item = _service.GetVoitureFonctionById(id);
			if (item != null)
			{
				return Ok(_mapper.Map<VoituresFonctionsDto>(item));
			}
			return NotFound();
		}

		// POST api/VoitureFonction
		[HttpPost]
		public ActionResult<VoituresFonctionsDto> CreateVoitureFonction(Voiturefonction vf)
		{
			//on ajoute l’objet à la base de données
			_service.AddVoitureFonctions(vf);
			//on retourne le chemin de findById avec l'objet créé
			return CreatedAtRoute(nameof(GetVoitureFonctionById), new { Id = vf.IdVoitures }, vf);
		}

		// PUT api/VoitureFonction/{id}
		[HttpPut("{id}")]
		public ActionResult UpdateVoitureFonction(int id, VoituresFonctionsDto vf)
		{
			var voitureFonctionFromRepo = _service.GetVoitureFonctionById(id);
			if (voitureFonctionFromRepo == null)
			{
				return NotFound();
			}
			voitureFonctionFromRepo.Dump();
			_mapper.Map(vf, voitureFonctionFromRepo);
			voitureFonctionFromRepo.Dump();

			_service.UpdateVoitureFonctions(voitureFonctionFromRepo);

			return NoContent();
		}

		// PATCH api/VoitureFonction/{id}
		[HttpPatch("{id}")]
		public ActionResult PartialVoitureEmployeUpdate(int id, JsonPatchDocument<Voiturefonction>
			patchDoc)
		{
			var voitureFonctionFromRepo = _service.GetVoitureFonctionById(id);
			if (voitureFonctionFromRepo == null)
			{
				return NotFound();
			}

			var voitureFonctionToPatch = _mapper.Map<Voiturefonction>(voitureFonctionFromRepo);

			patchDoc.ApplyTo(voitureFonctionFromRepo, ModelState);

			if (!TryValidateModel(voitureFonctionToPatch))
			{
				return ValidationProblem(ModelState);
			}
			voitureFonctionFromRepo.Dump();
			_mapper.Map(voitureFonctionToPatch, voitureFonctionFromRepo);
			voitureFonctionFromRepo.Dump();
			_service.UpdateVoitureFonctions(voitureFonctionFromRepo);

			return NoContent();
		}

		// DELETE api/Employe/{id}
		[HttpDelete("{id}")]
		public ActionResult DeleteVoitureFonction(int id)
		{
			var voitureFonctionModelFromRepo = _service.GetVoitureFonctionById(id);
			if (voitureFonctionModelFromRepo == null)
			{
				return NotFound();
			}

			_service.DeleteVoitureFonctions(voitureFonctionModelFromRepo);
			return NoContent();

		}
	}
}
