using Api.Models.Data;

namespace Api.Models.Services
{
	public class ClientService
	{

		// dbcontextname = Spectacle
		// classname =  Client
		// nameVar = s 

		private readonly SpectacleDBContext _context;
		public ClientService(SpectacleDBContext context)
		{
			_context = context;
		}

		public void AddClient(Client s)
		{
			if (s == null)
			{
				throw new ArgumentNullException(nameof(s));
			}
			_context.Clients.Add(s);
			_context.SaveChanges();
		}

		public void DeleteClient(Client s)
		{
			//si l'objet personne est null, on renvoi une exception
			if (s == null)
			{
				throw new ArgumentNullException(nameof(s));
			}
			// on met à jour le context
			_context.Clients.Remove(s);
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

		public void UpdateClient(Client s)
		{
			_context.SaveChanges();
		}


	}
}
