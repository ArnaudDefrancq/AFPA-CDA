using CRUD.Models.Data;

namespace CRUD.Models.Services
{
	public class AppartementService
	{
			
		private readonly ImmobilierDBContext _context;
		public AppartementService(ImmobilierDBContext context)
		{
			_context = context;
		}

		public void AddAppartement(Appartement a)
		{
			if (a == null)
			{
				throw new ArgumentNullException(nameof(a));
			}
			_context.Appartements.Add(a);
			_context.SaveChanges();
		}

		public void DeleteAppartement(Appartement a)
		{
			//si l'objet personne est null, on renvoi une exception
			if (a == null)
			{
				throw new ArgumentNullException(nameof(a));
			}
			// on met à jour le context
			_context.Appartements.Remove(a);
			_context.SaveChanges();
		}

		public IEnumerable<Appartement> GetAllAppartements()
		{
			return _context.Appartements.ToList();
		}

		public Appartement GetAppartementById(int id)
		{
			return _context.Appartements.FirstOrDefault(p => p.IdAppartement == id);
		}

		public void UpdateAppartement(Appartement a)
		{
			_context.SaveChanges();
		}
	}
}
