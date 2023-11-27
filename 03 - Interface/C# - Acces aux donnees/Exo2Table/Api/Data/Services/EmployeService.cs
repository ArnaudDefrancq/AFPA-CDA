using Api.Data.Models;

namespace Api.Data.Service
{
	public class EmployeServices
	{
		private readonly MyDBContext _context;

		public EmployeServices(MyDBContext context)
		{
			_context = context;
		}

		// Ajout d'une personne dans la base de donnée
		public void AddEmployes(Employe p)
		{
			if (p == null)
			{
				throw new ArgumentNullException(nameof(p));
			}
			_context.Employe.Add(p);
			_context.SaveChanges();
		}

		// Suppr une personne dans la base de donnée
		public void DeleteEmploye(Employe p)
		{
			if (p == null)
			{
				throw new ArgumentNullException(nameof(p));
			}
			_context.Employe.Remove(p);
			_context.SaveChanges();
		}

		// Donner la liste des personnes en base de donnée
		public IEnumerable<Employe> GetAllEmployes()
		{
			return _context.Employe.ToList();
		}

		// Donne une personne en particulier
		public Employe GetEmployeById(int id)
		{
			return _context.Employe.FirstOrDefault(p => p.IdEmploye == id)!;
		}

		// Permet de update une personne
		public void UpdateEmploye(Employe p)
		{

		}
	}
}

