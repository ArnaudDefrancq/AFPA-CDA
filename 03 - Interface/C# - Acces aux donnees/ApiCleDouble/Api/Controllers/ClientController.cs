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

	public class ClientController : ControllerBase
	{

		// Extend ControllerBase				
		private readonly ClientService _service;
		private readonly IMapper _mapper;

		public ClientController(ClientService service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		// GET api/Employe
		[HttpGet]
		public ActionResult<IEnumerable<ClientDto>> GetAllClients()
		{
			var liste = _service.GetAllClients();
			return Ok(_mapper.Map<IEnumerable<ClientDto>>(liste));
		}


		// GET  api/Employe/{id}
		[HttpGet("{id}", Name = "GetClientById")]
		public ActionResult<ClientDto> GetClientById(int id)
		{
			var item = _service.GetClientById(id);
			if (item != null)
			{
				return Ok(_mapper.Map<ClientDto>(item));
			}
			return NotFound();
		}


		// POST api/Employe
		[HttpPost]
		public ActionResult<ClientDto> CreateClient(Client c)
		{
			//on ajoute l’objet à la base de données
			_service.AddClient(c);
			//on retourne le chemin de findById avec l'objet créé
			return CreatedAtRoute(nameof(GetClientById), new { Id = c.IdClient }, c);
		}

		// PUT api/Employe/{id}
		[HttpPut("{id}")]
		public ActionResult UpdateClient(int id, ClientDto c)
		{
			var clientFromRepo = _service.GetClientById(id);
			if (clientFromRepo == null)
			{
				return NotFound();
			}
			clientFromRepo.Dump();
			_mapper.Map(c, clientFromRepo);
			clientFromRepo.Dump();
			_service.UpdateClient(clientFromRepo);
			return NoContent();
		}


		// DELETE api/Employe/{id}
		[HttpDelete("{id}")]
		public ActionResult DeleteClient(int id)
		{
			var clientModelFromRepo = _service.GetClientById(id);
			if (clientModelFromRepo == null)
			{
				return NotFound();
			}
			_service.DeleteClient(clientModelFromRepo);
			return NoContent();
		}



	}
}
