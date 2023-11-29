using Api.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Models.Services
{
	public class CadeauService
	{

		private readonly NoelDBContext _context;

		public CadeauService(NoelDBContext context)
		{
			_context = context;
		}

		public void AddCadeaus(Cadeau p)
		{
			if (p == null)
			{
				throw new ArgumentNullException(nameof(p));
			}
			_context.Cadeaus.Add(p);
			_context.SaveChanges();
		}

		public void DeleteCadeau(Cadeau p)
		{
			//si l'objet personne est null, on renvoi une exception
			if (p == null)
			{
				throw new ArgumentNullException(nameof(p));
			}
			// on met à jour le context
			_context.Cadeaus.Remove(p);
			_context.SaveChanges();
		}

		public IEnumerable<Cadeau> GetAllCadeaus()
		{
			return _context.Cadeaus.Include("Enfants").ToList();
		}

		public Cadeau GetCadeauById(int id)
		{
			return _context.Cadeaus.Include("Enfants").FirstOrDefault(p => p.IdCadeau == id);
		}

		public void UpdateCadeau(Cadeau p)
		{
			_context.SaveChanges();
		}

	}
}
