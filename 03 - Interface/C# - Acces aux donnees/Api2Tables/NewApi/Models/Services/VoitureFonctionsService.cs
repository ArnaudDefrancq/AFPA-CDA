using NewApi.Models.Data;

namespace NewApi.Models.Services
{
	public class VoitureFonctionsService
	{
		private readonly EntrepriseDbContext _context;

		public VoitureFonctionsService(EntrepriseDbContext context)
		{
			_context = context;
		}

		// Ajout d'une personne dans la base de donnée
		public void AddVoitureFonctions(Voiturefonction vf)
		{
			if (vf == null)
			{
				throw new ArgumentNullException(nameof(vf));
			}
			_context.Voiturefonctions.Add(vf);
			_context.SaveChanges();
		}

		// Suppr une personne dans la base de donnée
		public void DeleteVoitureFonctions(Voiturefonction vf)
		{
			if (vf == null)
			{
				throw new ArgumentNullException(nameof(vf));
			}
			_context.Voiturefonctions.Remove(vf);
			_context.SaveChanges();
		}

		// Donner la liste des personnes en base de donnée
		public IEnumerable<Voiturefonction> GetAllVoitureFonctions()
		{
			return _context.Voiturefonctions.ToList();
		}

		// Donne une personne en particulier
		public Voiturefonction GetVoitureFonctionById(int id)
		{
			return _context.Voiturefonctions.FirstOrDefault(v => v.IdVoitureFonction == id);
		}

		// Permet de update une personne
		public void UpdateVoitureFonctions(Voiturefonction vf)
		{
			_context.SaveChanges();
		}
	}
}
