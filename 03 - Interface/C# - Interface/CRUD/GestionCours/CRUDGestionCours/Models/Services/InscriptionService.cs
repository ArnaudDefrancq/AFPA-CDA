using CRUDGestionCours.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUDGestionCours.Models.Services
{
	public class InscriptionService
	{
		private readonly GestionCoursDBContext _context;
		public InscriptionService(GestionCoursDBContext context)
		{
			_context = context;
		}

		public void AddInscription(Inscription i)
		{
			if (i == null)
			{
				throw new ArgumentNullException(nameof(i));
			}
			_context.Inscriptions.Add(i);
			_context.SaveChanges();
		}

		public void DeleteInscription(Inscription i)
		{
			//si l'objet personne est null, on renvoi une exception
			if (i == null)
			{
				throw new ArgumentNullException(nameof(i));
			}
			// on met à jour le context
			_context.Inscriptions.Remove(i);
			_context.SaveChanges();
		}

		public IEnumerable<Inscription> GetAllInscriptions()
		{
			return _context.Inscriptions.Include("LeCours").Include("LeEtudiant").ToList();
		}

		public Inscription GetInscriptionById(int id)
		{
			return _context.Inscriptions.Include("LeCours").Include("LeEtudiant").FirstOrDefault(p => p.IdInscriptions == id);
		}

		public void UpdateInscription(Inscription i)
		{
			_context.SaveChanges();
		}
	}
}
