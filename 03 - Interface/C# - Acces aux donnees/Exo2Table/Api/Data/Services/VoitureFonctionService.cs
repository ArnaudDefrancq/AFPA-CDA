using Api.Data.Models;

namespace Api.Data
{
	public class VoitureFonctionServices
	{
		private readonly MyDBContext _context;

		public VoitureFonctionServices(MyDBContext context)
		{
			_context = context;
		}

		// Ajout d'une personne dans la base de donnée
		public void AddVoiture(Voiturefonction p)
		{
			if (p == null)
			{
				throw new ArgumentNullException(nameof(p));
			}
			_context.Voiturefonction.Add(p);
			_context.SaveChanges();
		}

		// Suppr une personne dans la base de donnée
		public void DeleteVoiture(Voiturefonction p)
		{
			if (p == null)
			{
				throw new ArgumentNullException(nameof(p));
			}
			_context.Voiturefonction.Remove(p);
			_context.SaveChanges();
		}

		// Donner la liste des personnes en base de donnée
		public IEnumerable<Voiturefonction> GetAllVoitures()
		{
			return _context.Voiturefonction.ToList();
		}

		// Donne une personne en particulier
		public Voiturefonction GetVoitureById(int id)
		{
			return _context.Voiturefonction.FirstOrDefault(p => p.IdVoitureFonction == id)!;
		}

		// Permet de update une personne
		public void UpdateVoiture(Voiturefonction p)
		{

		}
	}
}
