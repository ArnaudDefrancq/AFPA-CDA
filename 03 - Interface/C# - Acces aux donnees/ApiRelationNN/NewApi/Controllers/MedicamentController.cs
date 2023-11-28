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

	public class MedicamentController : ControllerBase
	{

		// Extend ControllerBase				
		private readonly MedicamentService _service;
		private readonly IMapper _mapper;

		public MedicamentController(MedicamentService service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		// GET api/Medicament
		[HttpGet]
		public ActionResult<IEnumerable<MedicamentDto>> GetAllMedicaments()
		{
			var liste = _service.GetAllMedicaments();
			return Ok(_mapper.Map<IEnumerable<MedicamentDto>>(liste));
		}


		// GET  api/Medicament/{id}
		[HttpGet("{id}", Name = "GetMedicamentById")]
		public ActionResult<MedicamentDto> GetMedicamentById(int id)
		{
			var item = _service.GetMedicamentById(id);
			if (item != null)
			{
				return Ok(_mapper.Map<MedicamentDto>(item));
			}
			return NotFound();
		}


		// POST api/Medicament
		[HttpPost]
		public ActionResult<MedicamentDto> CreateMedicament(Medicament m)
		{
			//on ajoute l’objet à la base de données
			_service.AddMedicament(m);
			//on retourne le chemin de findById avec l'objet créé
			return CreatedAtRoute(nameof(GetMedicamentById), new { Id = m.IdMedicament }, m);
		}


		// PUT api/Medicament/{id}
		[HttpPut("{id}")]
		public ActionResult UpdateMedicament(int id, Medicament m)
		{
			var medicamentFromRepo = _service.GetMedicamentById(id);
			if (medicamentFromRepo == null)
			{
				return NotFound();
			}
			medicamentFromRepo.Dump();
			_mapper.Map(m, medicamentFromRepo);
			medicamentFromRepo.Dump();
			_service.UpdateMedicament(medicamentFromRepo);
			return NoContent();
		}


		// DELETE api/Medicament/{id}
		[HttpDelete("{id}")]
		public ActionResult DeleteMedicament(int id)
		{
			var medicamentModelFromRepo = _service.GetMedicamentById(id);
			if (medicamentModelFromRepo == null)
			{
				return NotFound();
			}
			_service.DeleteMedicament(medicamentModelFromRepo);
			return NoContent();
		}



	}
}
