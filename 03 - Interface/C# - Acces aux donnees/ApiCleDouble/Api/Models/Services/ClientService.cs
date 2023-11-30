// dbcontextname = Spectacle
// classname =  Client
// nameVar = c
// projetName  = Api

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

		public void AddClient(Client c)
		{
			if (c == null)
			{
				throw new ArgumentNullException(nameof(c));
			}
			_context.Clients.Add(c);
			_context.SaveChanges();
		}

		public void DeleteClient(Client c)
		{
			//si l'objet personne est null, on renvoi une exception
			if (c == null)
			{
				throw new ArgumentNullException(nameof(c));
			}
			// on met à jour le context
			_context.Clients.Remove(c);
			_context.SaveChanges();
		}

		public IEnumerable<Client> GetAllClients()
		{
			return _context.Clients.ToList();
		}

		public Client GetClientById(int id)
		{
			return _context.Clients.FirstOrDefault(p => p.IdClient == id);
		}

		public void UpdateClient(Client c)
		{
			_context.SaveChanges();
		}
	}
}

