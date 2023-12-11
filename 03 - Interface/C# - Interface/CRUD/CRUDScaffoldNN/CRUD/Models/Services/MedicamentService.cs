using CRUD.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUD.Models.Services
{
	public class MedicamentService
	{
		private readonly medecinedbDBContext _context;
		public MedicamentService(medecinedbDBContext context)
		{
			_context = context;
		}

		public void AddMedicament(Medicament m)
		{
			if (m == null)
			{
				throw new ArgumentNullException(nameof(m));
			}
			_context.Medicaments.Add(m);
			_context.SaveChanges();
		}

		public void DeleteMedicament(Medicament m)
		{
			//si l'objet personne est null, on renvoi une exception
			if (m == null)
			{
				throw new ArgumentNullException(nameof(m));
			}
			// on met à jour le context
			_context.Medicaments.Remove(m);
			_context.SaveChanges();
		}

		public IEnumerable<Medicament> GetAllMedicaments()
		{
			return _context.Medicaments.Include("Prescriptions.LeSoignant").ToList();
		}

		public Medicament GetMedicamentById(int id)
		{
			return _context.Medicaments.Include("Prescriptions.LeSoignant").FirstOrDefault(p => p.IdMedicament == id);
		}

		public void UpdateMedicament(Medicament m)
		{
			_context.SaveChanges();
		}
	}
}
