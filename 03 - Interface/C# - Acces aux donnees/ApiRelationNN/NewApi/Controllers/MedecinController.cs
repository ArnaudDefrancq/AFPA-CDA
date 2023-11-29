using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewApi.Helpers;
using NewApi.Models.Data;
using NewApi.Models.Dtos;
using NewApi.Models.Services;

namespace NewApi.Controllers
{
	[Route("api/[Controller]")]
	[ApiController]
	public class MedecinController : ControllerBase
	{
		// Extend ControllerBase				
		private readonly MedecinService _service;
		private readonly IMapper _mapper;

		public MedecinController(MedecinService service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		// GET api/Medecin
		[HttpGet]
		public ActionResult<IEnumerable<MedecinDtoAplatie>> GetAllMedecins()
		{
			var liste = _service.GetAllMedecins();
			return Ok(_mapper.Map<IEnumerable<MedecinDtoAplatie>>(liste));
		}


		// GET  api/Medecin/{id}
		[HttpGet("{id}", Name = "GetMedecinById")]
		public ActionResult<MedecinDto> GetMedecinById(int id)
		{
			var item = _service.GetMedecinById(id);
			if (item != null)
			{
				return Ok(_mapper.Map<MedecinDto>(item));
			}
			return NotFound();
		}


		// POST api/Medecin
		[HttpPost]
		public ActionResult<MedecinDtoPost> CreateEmploye(Medecin m)
		{
			//on ajoute l’objet à la base de données
			_service.AddMedecin(m);
			//on retourne le chemin de findById avec l'objet créé
			return CreatedAtRoute(nameof(GetMedecinById), new { Id = m.IdMedecin }, m);
		}


		// PUT api/Medecin/{id}
		[HttpPut("{id}")]
		public ActionResult UpdateMedecin(int id, MedecinDto m)
		{
			var medecinFromRepo = _service.GetMedecinById(id);
			if (medecinFromRepo == null)
			{
				return NotFound();
			}
			medecinFromRepo.Dump();
			_mapper.Map(m, medecinFromRepo);
			medecinFromRepo.Dump();
			_service.UpdateMedecin(medecinFromRepo);
			return NoContent();
		}


		// DELETE api/Medecin/{id}
		[HttpDelete("{id}")]
		public ActionResult DeleteMedecin(int id)
		{
			var medecinModelFromRepo = _service.GetMedecinById(id);
			if (medecinModelFromRepo == null)
			{
				return NotFound();
			}
			_service.DeleteMedecin(medecinModelFromRepo);
			return NoContent();
		}



	}
}
