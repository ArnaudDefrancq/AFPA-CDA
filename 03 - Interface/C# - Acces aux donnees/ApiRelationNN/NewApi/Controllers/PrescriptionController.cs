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

	public class PrescriptionController : ControllerBase
	{


		// Extend ControllerBase				
		private readonly PrescriptionService _service;
		private readonly IMapper _mapper;

		public PrescriptionController(PrescriptionService service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		// GET api/Prescription
		[HttpGet]
		public ActionResult<IEnumerable<PrescriptionDto>> GetAllPresciptions()
		{
			var liste = _service.GetAllPrescriptions();
			return Ok(_mapper.Map<IEnumerable<PrescriptionDto>>(liste));
		}


		// GET  api/Prescription/{id}
		[HttpGet("{id}", Name = "GetPrescriptionById")]
		public ActionResult<PrescriptionDto> GetPrescriptionById(int id)
		{
			var item = _service.GetPrescriptionById(id);
			if (item != null)
			{
				return Ok(_mapper.Map<PrescriptionDto>(item));
			}
			return NotFound();
		}


		// POST api/Prescription
		[HttpPost]
		public ActionResult<PrescriptionDtoPost> CreateEmploye(Prescription p)
		{
			//on ajoute l’objet à la base de données
			_service.AddPrescription(p);
			//on retourne le chemin de findById avec l'objet créé
			return CreatedAtRoute(nameof(GetPrescriptionById), new { Id = p.IdPrescription }, p);
		}


		// PUT api/Prescription/{id}
		[HttpPut("{id}")]
		public ActionResult UpdatePrescription(int id, PrescriptionDto p)
		{
			var prescriptionFromRepo = _service.GetPrescriptionById(id);
			if (prescriptionFromRepo == null)
			{
				return NotFound();
			}
			prescriptionFromRepo.Dump();
			_mapper.Map(p, prescriptionFromRepo);
			prescriptionFromRepo.Dump();
			_service.UpdatePrescription(prescriptionFromRepo);
			return NoContent();
		}



		// DELETE api/Prescription/{id}
		[HttpDelete("{id}")]
		public ActionResult DeletePrescription(int id)
		{
			var prescriptionModelFromRepo = _service.GetPrescriptionById(id);
			if (prescriptionModelFromRepo == null)
			{
				return NotFound();
			}
			_service.DeletePrescription(prescriptionModelFromRepo);
			return NoContent();
		}



	}
}
