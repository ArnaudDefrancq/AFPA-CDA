using Api.Data.Models;

namespace Api.Data.Services
{
	public class PersonnesServices
	{
		private readonly MyDBContext _context;

		public PersonnesServices(MyDBContext context)
		{
			_context = context;
		}

		// Ajout d'une personne dans la base de donnée
		public void AddPersonnes(Employe p)
		{
			if (p == null)
			{
				throw new ArgumentNullException(nameof(p));
			}
			_context.Employes.Add(p);
			_context.SaveChanges();
		}

		// Suppr une personne dans la base de donnée
		public void DeletePersonne(Employe p)
		{
			if (p == null)
			{
				throw new ArgumentNullException(nameof(p));
			}
			_context.Employes.Remove(p);
			_context.SaveChanges();
		}

		// Donner la liste des personnes en base de donnée
		public IEnumerable<Employe> GetAllPersonnes()
		{
			return _context.Employes.ToList();
		}

		// Donne une personne en particulier
		public Employe GetPersonneById(int id)
		{
			return _context.Employes.FirstOrDefault(p => p.IdEmploye == id)!;
		}

		// Permet de update une personne
		public void UpdatePersonne(Employe p)
		{

		}
	}
}

