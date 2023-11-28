using Microsoft.EntityFrameworkCore;
using NewApi.Models.Data;

namespace NewApi.Models.Services
{
	public class MedecinService
	{

		private readonly MedecineDBContext _context;

		public MedecinService(MedecineDBContext context)
		{
			_context = context;
		}

		// Ajout d'une personne dans la base de donnée
		public void AddMedecin(Medecin m)
		{
			if (m == null)
			{
				throw new ArgumentNullException(nameof(m));
			}
			_context.Medecins.Add(m);
			_context.SaveChanges();
		}


		// Suppr une personne dans la base de donnée
		public void DeleteMedecin(Medecin m)
		{
			if (m == null)
			{
				throw new ArgumentNullException(nameof(m));
			}
			_context.Medecins.Remove(m);
			_context.SaveChanges();
		}


		// Donner la liste des personnes en base de donnée
		public IEnumerable<Medecin> GetAllMedecins()
		{
			return _context.Medecins.Include("Prescriptions").ToList();
		}


		// Donne une personne en particulier
		public Medecin GetMedecinById(int id)
		{
			return _context.Medecins.Include("Prescriptions").FirstOrDefault(v => v.IdMedecin == id);
		}


		// Permet de update une personne
		public void UpdateMedecin(Medecin m)
		{
			_context.SaveChanges();
		}





	}
}
