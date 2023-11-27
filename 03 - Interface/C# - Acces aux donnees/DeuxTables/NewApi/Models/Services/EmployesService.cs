using NewApi.Models.Data;

namespace NewApi.Models.Services
{
	public class EmployesService
	{
		private readonly EntrepriseDbContext _context;

		public EmployesService(EntrepriseDbContext context)
		{
			_context = context;
		}

		// Ajout d'une personne dans la base de donnée
		public void AddEmploye(Employe e)
		{
			if (e == null)
			{
				throw new ArgumentNullException(nameof(e));
			}
			_context.Employes.Add(e);
			_context.SaveChanges();
		}

		// Suppr une personne dans la base de donnée
		public void DeleteEmploye(Employe e)
		{
			if (e == null)
			{
				throw new ArgumentNullException(nameof(e));
			}
			_context.Employes.Remove(e);
			_context.SaveChanges();
		}

		// Donner la liste des personnes en base de donnée
		public IEnumerable<Employe> GetAllEmployes()
		{
			return _context.Employes.ToList();
		}

		// Donne une personne en particulier
		public Employe GetEmployeById(int id)
		{
			return _context.Employes.FirstOrDefault(v => v.IdEmploye == id);
		}

		// Permet de update une personne
		public void UpdateEmploye(Employe e)
		{
			_context.SaveChanges();
		}
	}
}
