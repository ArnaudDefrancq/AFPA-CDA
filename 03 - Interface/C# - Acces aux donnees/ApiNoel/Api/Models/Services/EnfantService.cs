using Api.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Models.Services
{
	public class EnfantService
	{

		private readonly NoelDBContext _context;
		public EnfantService(NoelDBContext context)
		{
			_context = context;
		}

		public void AddEnfants(Enfant p)
		{
			if (p == null)
			{
				throw new ArgumentNullException(nameof(p));
			}
			_context.Enfants.Add(p);
			_context.SaveChanges();
		}

		public void DeleteEnfant(Enfant p)
		{
			//si l'objet personne est null, on renvoi une exception
			if (p == null)
			{
				throw new ArgumentNullException(nameof(p));
			}
			// on met à jour le context
			_context.Enfants.Remove(p);
			_context.SaveChanges();
		}

		public IEnumerable<Enfant> GetAllEnfants()
		{
			return _context.Enfants.Include("LeCadeau").ToList();
		}

		public Enfant GetEnfantById(int id)
		{
			return _context.Enfants.Include("LeCadeau").FirstOrDefault(p => p.IdEnfant == id);
		}

		public void UpdateEnfant(Enfant p)
		{
			_context.SaveChanges();
		}

	}
}
