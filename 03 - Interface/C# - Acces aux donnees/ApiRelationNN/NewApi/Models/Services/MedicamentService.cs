using NewApi.Models.Data;

namespace NewApi.Models.Services
{
	public class MedicamentService
	{

		private readonly MedecineDBContext _context;

		public MedicamentService(MedecineDBContext context)
		{
			_context = context;
		}

		// Ajout d'une personne dans la base de donnée
		public void AddMedicament(Medicament m)
		{
			if (m == null)
			{
				throw new ArgumentNullException(nameof(m));
			}
			_context.Medicaments.Add(m);
			_context.SaveChanges();
		}


		// Suppr une personne dans la base de donnée
		public void DeleteMedicament(Medicament m)
		{
			if (m == null)
			{
				throw new ArgumentNullException(nameof(m));
			}
			_context.Medicaments.Remove(m);
			_context.SaveChanges();
		}


		// Donner la liste des personnes en base de donnée
		public IEnumerable<Medicament> GetAllMedicaments()
		{
			return _context.Medicaments.ToList();
		}


		// Donne une personne en particulier
		public Medicament GetMedicamentById(int id)
		{
			return _context.Medicaments.FirstOrDefault(v => v.IdMedicament == id);
		}


		// Permet de update une personne
		public void UpdateMedicament(Medicament m)
		{
			_context.SaveChanges();
		}




	}
}
