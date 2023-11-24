namespace Api.Models.Data.Services
{
	public class PersonnesServices
	{
		private readonly MyDBContext _context;

		public PersonnesServices(MyDBContext context)
		{
			_context = context;
		}

		// Ajout d'une personne dans la base de donnée
		public void AddPersonnes(Personne p)
		{
			if (p == null)
			{
				throw new ArgumentNullException(nameof(p));
			}
			_context.Personnes.Add(p);
			_context.SaveChanges();
		}

		// Suppr une personne dans la base de donnée
		public void DeletePersonne(Personne p)
		{
			if (p == null)
			{
				throw new ArgumentNullException(nameof(p));
			}
			_context.Personnes.Remove(p);
			_context.SaveChanges();
		}

		// Donner la liste des personnes en base de donnée
		public IEnumerable<Personne> GetAllPersonnes()
		{
			return _context.Personnes.ToList();
		}

		// Donne une personne en particulier
		public Personne GetPersonneById(int id)
		{
			return _context.Personnes.FirstOrDefault(p => p.Id == id);
		}

		// Permet de update une personne
		public void UpdatePersonne(Personne p)
		{

		}
	}
}
