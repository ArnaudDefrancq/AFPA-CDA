using Api.Models.Data;

namespace Api.Models.Services
{
	public class PrestationService
	{

		private readonly SpectacleDBContext _context;

		public PrestationService(SpectacleDBContext context)
		{
			_context = context;
		}

		// Ajout d'une personne dans la base de donnée
		public void AddPrestation(Prestation p)
		{
			if (p == null)
			{
				throw new ArgumentNullException(nameof(p);
			}
			_context.Prestations.Add(p);
			_context.SaveChanges();
		}


		// Suppr une personne dans la base de donnée
		public void DeletePrestation(Prestation p)
		{
			if (p == null)
			{
				throw new ArgumentNullException(nameof(p));
			}
			_context.Prestations.Remove(p);
			_context.SaveChanges();
		}


		// Donner la liste des personnes en base de donnée
		public IEnumerable<Prestation> GetAllPrestations()
		{
			return _context.Prestations.ToList();
		}


		// Donne une personne en particulier
		public Prestation GetPrestationById(int id)
		{
			return _context.Prestations.FirstOrDefault(v => v.IdPrestation == id);
		}



		// Permet de update une personne
		public void UpdatePrestation(Prestation p)
		{
			_context.SaveChanges();
		}



	}
}
