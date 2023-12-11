using CRUD.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUD.Models.Services
{
	public class MedecinService
	{
		private readonly medecinedbDBContext _context;
		public MedecinService(medecinedbDBContext context)
		{
			_context = context;
		}

		public void AddMedecin(Medecin m)
		{
			if (m == null)
			{
				throw new ArgumentNullException(nameof(m));
			}
			_context.Medecins.Add(m);
			_context.SaveChanges();
		}

		public void DeleteMedecin(Medecin m)
		{
			//si l'objet personne est null, on renvoi une exception
			if (m == null)
			{
				throw new ArgumentNullException(nameof(m));
			}
			// on met à jour le context
			_context.Medecins.Remove(m);
			_context.SaveChanges();
		}

		public IEnumerable<Medecin> GetAllMedecins()
		{
			return _context.Medecins.Include("Prescriptions.LeMedicament").ToList();
		}

		public Medecin GetMedecinById(int id)
		{
			return _context.Medecins.Include("Prescriptions.LeMedicament").FirstOrDefault(p => p.IdMedecin == id);
		}

		public void UpdateMedecin(Medecin m)
		{
			_context.SaveChanges();
		}
	}
}
