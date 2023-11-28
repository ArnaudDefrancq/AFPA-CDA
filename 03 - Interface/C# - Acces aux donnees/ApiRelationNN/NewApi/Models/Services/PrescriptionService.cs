using NewApi.Models.Data;

namespace NewApi.Models.Services
{
	public class PrescriptionService
	{
		private readonly MedecineDBContext _context;

		public PrescriptionService(MedecineDBContext context)
		{
			_context = context;
		}

		// Ajout d'une personne dans la base de donnée
		public void AddPrescription(Prescription p)
		{
			if (p == null)
			{
				throw new ArgumentNullException(nameof(p));
			}
			_context.Prescriptions.Add(p);
			_context.SaveChanges();
		}


		// Suppr une personne dans la base de donnée
		public void DeletePrescription(Prescription p)
		{
			if (p == null)
			{
				throw new ArgumentNullException(nameof(p));
			}
			_context.Prescriptions.Remove(p);
			_context.SaveChanges();
		}


		// Donner la liste des personnes en base de donnée
		public IEnumerable<Prescription> GetAllPrescriptions()
		{
			return _context.Prescriptions.ToList();
		}


		// Donne une personne en particulier
		public Prescription GetPrescriptionById(int id)
		{
			return _context.Prescriptions.FirstOrDefault(v => v.IdPrescription == id);
		}


		// Permet de update une personne
		public void UpdatePrescription(Prescription p)
		{
			_context.SaveChanges();
		}



	}
}
