using Api.Models.Data;

namespace Api.Models.Services
{
	public class ClientService
	{
		private readonly SpectacleDBContext _context;

		public ClientService(SpectacleDBContext context)
		{
			_context = context;
		}

		// Ajout d'une personne dans la base de donnée
		public void AddClient(Client c)
		{
			if (c == null)
			{
				throw new ArgumentNullException(nameof(c));
			}
			_context.Clients.Add(c);
			_context.SaveChanges();
		}


		// Suppr une personne dans la base de donnée
		public void DeleteClient(Client c)
		{
			if (c == null)
			{
				throw new ArgumentNullException(nameof(c));
			}
			_context.Clients.Remove(c);
			_context.SaveChanges();
		}


		// Donner la liste des personnes en base de donnée
		public IEnumerable<Client> GetAllClients()
		{
			return _context.Clients.ToList();
		}


		// Donne une personne en particulier
		public Client GetClientById(int id)
		{
			return _context.Clients.FirstOrDefault(v => v.IdClient == id);
		}



		// Permet de update une personne
		public void UpdateClient(Client c)
		{
			_context.SaveChanges();
		}



	}
}

