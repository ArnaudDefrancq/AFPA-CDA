
namespace Api.Models.Data.Services
{
	public class VoituresService
	{
		private readonly VoituresDbContext _context;

		public VoituresService(VoituresDbContext context)
		{
			_context = context;
		}

		// Ajout d'une personne dans la base de donnée
		public void AddVoitures(Voiture v)
		{
			if (v == null)
			{
				throw new ArgumentNullException(nameof(v));
			}
			_context.Voitures.Add(v);
			_context.SaveChanges();
		}

		// Suppr une personne dans la base de donnée
		public void DeleteVoiture(Voiture v)
		{
			if (v == null)
			{
				throw new ArgumentNullException(nameof(v));
			}
			_context.Voitures.Remove(v);
			_context.SaveChanges();
		}

		// Donner la liste des personnes en base de donnée
		public IEnumerable<Voiture> GetAllVoitures()
		{
			return _context.Voitures.ToList();
		}

		// Donne une personne en particulier
		public Voiture GetVoitureById(int id)
		{
			return _context.Voitures.FirstOrDefault(v => v.IdVoiture == id);
		}

		// Permet de update une personne
		public void UpdateVoiture(Voiture v)
		{
			_context.SaveChanges();
		}
	}
}
