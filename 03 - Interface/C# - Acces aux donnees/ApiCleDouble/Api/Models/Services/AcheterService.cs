using Api.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Models.Services
{
	public class AcheterService
	{
		private readonly SpectacleDBContext _context;

		public AcheterService(SpectacleDBContext context)
		{
			_context = context;
		}

		// Ajout d'une personne dans la base de donnée
		public void AddAcheter(Acheter a)
		{
			if (a == null)
			{
				throw new ArgumentNullException(nameof(a));
			}
			_context.Acheters.Add(a);
			_context.SaveChanges();
		}


		// Suppr une personne dans la base de donnée
		public void DeleteAcheter(Acheter a)
		{
			if (a == null)
			{
				throw new ArgumentNullException(nameof(a));
			}
			_context.Acheters.Remove(a);
			_context.SaveChanges();
		}


		// Donner la liste des personnes en base de donnée
		public IEnumerable<Acheter> GetAllAcheters()
		{
			return _context.Acheters.Include("ListClients").Include("ListPrestations").ToList();
		}


		// Donne une personne en particulier
		public Acheter GetAcheterById(int id)
		{
			return _context.Acheters.Include("ListClients").Include("ListPrestations").FirstOrDefault(a => a.IdClient == id && a.IdPrestation == id);
		}



		// Permet de update une personne
		public void UpdateAcheter(Acheter a)
		{
			_context.SaveChanges();
		}


	}
}
