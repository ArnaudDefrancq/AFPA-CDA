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

	public class AcheterController : ControllerBase
	{

		// Extend ControllerBase				
		private readonly AcheterService _service;
		private readonly IMapper _mapper;

		public AcheterController(AcheterService service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		// GET api/Employe
		[HttpGet]
		public ActionResult<IEnumerable<AcheterDto>> GetAllAcheters()
		{
			var liste = _service.GetAllAcheters();
			return Ok(_mapper.Map<IEnumerable<AcheterDto>>(liste));
		}


		// GET  api/Employe/{id}
		[HttpGet("{id}", Name = "GetAcheterById")]
		public ActionResult<AcheterDto> GetAcheterById(int id)
		{
			var item = _service.GetAcheterById(id);
			if (item != null)
			{
				return Ok(_mapper.Map<AcheterDto>(item));
			}
			return NotFound();
		}


		// POST api/Employe
		[HttpPost]
		public ActionResult<AcheterDto> CreateAcheter(Acheter c)
		{
			//on ajoute l’objet à la base de données
			_service.AddAcheter(c);
			//on retourne le chemin de findById avec l'objet créé
			return CreatedAtRoute(nameof(GetAcheterById), new { Id = c.IdClient }, c);
		}

		// PUT api/Employe/{id}
		[HttpPut("{id}")]
		public ActionResult UpdateAcheter(int id, AcheterDto c)
		{
			var achterFromRepo = _service.GetAcheterById(id);
			if (achterFromRepo == null)
			{
				return NotFound();
			}
			achterFromRepo.Dump();
			_mapper.Map(c, achterFromRepo);
			achterFromRepo.Dump();
			_service.UpdateAcheter(achterFromRepo);
			return NoContent();
		}


		// DELETE api/Employe/{id}
		[HttpDelete("{id}")]
		public ActionResult DeleteAcheter(int id)
		{
			var acheterModelFromRepo = _service.GetAcheterById(id);
			if (acheterModelFromRepo == null)
			{
				return NotFound();
			}
			_service.DeleteAcheter(acheterModelFromRepo);
			return NoContent();
		}
	}
}
