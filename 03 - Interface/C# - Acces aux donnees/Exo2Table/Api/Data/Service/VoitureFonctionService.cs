using Api.Data.Models;

namespace Api.Data
{
	public class PersonnesServices
	{
		private readonly MyDBContext _context;

		public PersonnesServices(MyDBContext context)
		{
			_context = context;
		}

		// Ajout d'une personne dans la base de donnée
		public void AddPersonnes(Voiturefonction p)
		{
			if (p == null)
			{
				throw new ArgumentNullException(nameof(p));
			}
			_context.Voiturefonctions.Add(p);
			_context.SaveChanges();
		}

		// Suppr une personne dans la base de donnée
		public void DeletePersonne(Voiturefonction p)
		{
			if (p == null)
			{
				throw new ArgumentNullException(nameof(p));
			}
			_context.Voiturefonctions.Remove(p);
			_context.SaveChanges();
		}

		// Donner la liste des personnes en base de donnée
		public IEnumerable<Voiturefonction> GetAllPersonnes()
		{
			return _context.Voiturefonctions.ToList();
		}

		// Donne une personne en particulier
		public Voiturefonction GetPersonneById(int id)
		{
			return _context.Voiturefonctions.FirstOrDefault(p => p.IdVoitureFonction == id)!;
		}

		// Permet de update une personne
		public void UpdatePersonne(Voiturefonction p)
		{

		}
	}
}
