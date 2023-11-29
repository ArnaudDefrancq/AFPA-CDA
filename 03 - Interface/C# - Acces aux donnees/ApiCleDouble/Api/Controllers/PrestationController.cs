using Api.Helpers;
using Api.Models.Data;
using Api.Models.Dtos;
using Api.Models.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

	[Route("api/[Controller]")]
	[ApiController]

	public class PrestationController
	{
		// Extend ControllerBase				
		private readonly PrestationService _service;
		private readonly IMapper _mapper;

		public PrestationController(PrestationService service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		// GET api/Employe
		[HttpGet]
		public ActionResult<IEnumerable<PrestationDto>> GetAllPrestations()
		{
			var liste = _service.GetAllPrestations();
			return Ok(_mapper.Map<IEnumerable<PrestationDto>>(liste));
		}


		// GET  api/Employe/{id}
		[HttpGet("{id}", Name = "GetPrestationById")]
		public ActionResult<PrestationDto> GetPrestationById(int id)
		{
			var item = _service.GetPrestationById(id);
			if (item != null)
			{
				return Ok(_mapper.Map<PrestationDto>(item));
			}
			return NotFound();
		}


		// POST api/Employe
		[HttpPost]
		public ActionResult<ClientDto> CreatePrestation(Prestation p)
		{
			//on ajoute l’objet à la base de données
			_service.AddPrestation(p);
			//on retourne le chemin de findById avec l'objet créé
			return CreatedAtRoute(nameof(GetPrestationById), new { Id = p.IdPrestation }, p);
		}

		// PUT api/Employe/{id}
		[HttpPut("{id}")]
		public ActionResult UpdatePrestation(int id, PrestationDto p)
		{
			var prestationFromRepo = _service.GetPrestationById(id);
			if (prestationFromRepo == null)
			{
				return NotFound();
			}
			prestationFromRepo.Dump();
			_mapper.Map(p, prestationFromRepo);
			prestationFromRepo.Dump();
			_service.UpdatePrestation(prestationFromRepo);
			return NoContent();
		}


		// DELETE api/Employe/{id}
		[HttpDelete("{id}")]
		public ActionResult DeletePrestation(int id)
		{
			var prestationModelFromRepo = _service.GetPrestationById(id);
			if (prestationModelFromRepo == null)
			{
				return NotFound();
			}
			_service.DeletePrestation(prestationModelFromRepo);
			return NoContent();
		}
	}
}
