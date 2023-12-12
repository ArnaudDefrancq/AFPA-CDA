using AutoMapper;
using gestionStock.Models.Data;
using gestionStock.Models.Dtos;
using gestionStock.Models.Services;
using gestionStock.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using gestionStock.Models.Profiles;

namespace gestionStock.Controllers
{
	public class TypesProduitController : ControllerBase
	{
		private readonly TypesProduitService _service;
		private readonly IMapper _mapper;

		public TypesProduitController(GestionStocksDBContext context)
		{
			_service = new TypesProduitService(context);
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<TypesProduitProfile>();
			});
			_mapper = config.CreateMapper();
		}


		public IEnumerable<TypesProduitDtoAplatie> GetAllTypesProduits()
		{
			IEnumerable<TypesProduit> liste = _service.GetAllTypesproduits();
			return _mapper.Map<IEnumerable<TypesProduitDtoAplatie>>(liste);
		}


		public ActionResult<TypesProduit> GetTypesProduitById(int id)
		{
			TypesProduit item = _service.GetTypesproduitById(id);
			if (item != null)
			{
				return Ok(_mapper.Map<TypesProduit>(item));
			}
			return NotFound();
		}


		public ActionResult<TypesProduit> CreateTypesProduit(TypesProduitDtoIn obj)
		{
			TypesProduit newItem = _mapper.Map<TypesProduit>(obj);
			_service.AddTypesproduit(newItem);
			return CreatedAtRoute(nameof(GetTypesProduitById), new { Id = newItem.IdTypeProduit }, newItem);
		}

		public ActionResult UpdateTypesProduit(int id, TypesProduitDtoIn obj)
		{
			TypesProduit objFromRepo = _service.GetTypesproduitById(id);
			if (objFromRepo == null)
			{
				return NotFound();
			}
			_mapper.Map(obj, objFromRepo);
			// inutile puisque la fonction ne fait rien, mais garde la cohérence
			_service.UpdateTypesproduit(objFromRepo);
			return NoContent();
		}

		public ActionResult DeleteTypesProduit(int id)
		{
			TypesProduit obj = _service.GetTypesproduitById(id);
			if (obj == null)
			{
				return NotFound();
			}
			_service.DeleteTypesproduit(obj);
			return NoContent();
		}
	}
}
