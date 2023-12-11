using CRUD.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Models.Services
{
	public class PrescriptionService
	{
		private readonly medecinedbDBContext _context;
		public PrescriptionService(medecinedbDBContext context)
		{
			_context = context;
		}

		public void AddPrescription(Prescription p)
		{
			if (p == null)
			{
				throw new ArgumentNullException(nameof(p));
			}
			_context.Prescriptions.Add(p);
			_context.SaveChanges();
		}

		public void DeletePrescription(Prescription p)
		{
			//si l'objet personne est null, on renvoi une exception
			if (p == null)
			{
				throw new ArgumentNullException(nameof(p));
			}
			// on met à jour le context
			_context.Prescriptions.Remove(p);
			_context.SaveChanges();
		}

		public IEnumerable<Prescription> GetAllPrescriptions()
		{
			return _context.Prescriptions.Include("LeMedicament").Include("LeSoignant").ToList();
		}

		public Prescription GetPrescriptionById(int id)
		{
			return _context.Prescriptions.Include("LeMedicament").Include("LeSoignant").FirstOrDefault(p => p.IdPrescription == id);
		}

		public void UpdatePrescription(Prescription p)
		{
			_context.SaveChanges();
		}
	}
}
