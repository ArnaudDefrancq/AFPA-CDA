using AutoMapper;
using CRUD.Models.Data;
using CRUD.Models.Dtos;
using CRUD.Models.Services;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using CRUD.Models.Profiles;

namespace CRUD.Controllers
{
	public class AppartementController : ControllerBase
	{
		private readonly AppartementService _service;
		private readonly IMapper _mapper;

		public AppartementController(ImmobilierDBContext context)
		{
			_service = new ImmobilierDBContext(context);
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<AppartementProfile>();
			});
			_mapper = config.CreateMapper();
		}


		public IEnumerable<AppartementDtoApplatieAvecCategorie> GetAllAppartements()
		{
			IEnumerable<Appartement> liste = _service.GetAllAppartements();
			return _mapper.Map<IEnumerable<AppartementDtoApplatieAvecCategorie>>(liste);
		}


		public ActionResult<Appartement> GetAppartementById(int id)
		{
			Appartement item = _service.GetAppartementById(id);
			if (item != null)
			{
				return Ok(_mapper.Map<Appartement>(item));
			}
			return NotFound();
		}


		public ActionResult<Appartement> CreateAppartement(AppartementDtoIn obj)
		{
			Appartement newItem = _mapper.Map<Appartement>(obj);
			_service.AddAppartement(newItem);
			return CreatedAtRoute(nameof(GetAppartementById), new { Id = newItem.IdAppartement }, newItem);
		}

		public ActionResult UpdateAppartement(int id, AppartementDtoIn obj)
		{
			Appartement objFromRepo = _service.GetAppartementById(id);
			if (objFromRepo == null)
			{
				return NotFound();
			}
			_mapper.Map(obj, objFromRepo);
			// inutile puisque la fonction ne fait rien, mais garde la cohérence
			_service.UpdateAppartement(objFromRepo);
			return NoContent();
		}

		public ActionResult DeleteAppartement(int id)
		{
			Appartement obj = _service.GetAppartementById(id);
			if (obj == null)
			{
				return NotFound();
			}
			_service.DeleteAppartement(obj);
			return NoContent();
		}
	}
}
