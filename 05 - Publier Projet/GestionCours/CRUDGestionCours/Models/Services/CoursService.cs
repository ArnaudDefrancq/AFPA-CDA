using CRUDGestionCours.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUDGestionCours.Models.Services
{
	public class CoursService
	{
		private readonly GestionCoursDBContext _context;
		public CoursService(GestionCoursDBContext context)
		{
			_context = context;
		}

		public void AddCours(Cour c)
		{
			if (c == null)
			{
				throw new ArgumentNullException(nameof(c));
			}
			_context.Cours.Add(c);
			_context.SaveChanges();
		}

		public void DeleteCours(Cour c)
		{
			//si l'objet personne est null, on renvoi une exception
			if (c == null)
			{
				throw new ArgumentNullException(nameof(c));
			}
			// on met à jour le context
			_context.Cours.Remove(c);
			_context.SaveChanges();
		}

		public IEnumerable<Cour> GetAllCours()
		{
			return _context.Cours.Include("Inscriptions.LeEtudiant").ToList();
		}

		public Cour GetCoursById(int id)
		{
			return _context.Cours.Include("Inscriptions.LeEtudiant").FirstOrDefault(p => p.IdCours == id);
		}

		public void UpdateCours(Cour c)
		{
			_context.SaveChanges();
		}
	}
}
