using CRUDGestionCours.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDGestionCours.Models.Services
{
	public class EtudiantService
	{
		private readonly GestionCoursDBContext _context;
		public EtudiantService(GestionCoursDBContext context)
		{
			_context = context;
		}

		public void AddEtudiant(Etudiant e)
		{
			if (e == null)
			{
				throw new ArgumentNullException(nameof(e));
			}
			_context.Etudiants.Add(e);
			_context.SaveChanges();
		}

		public void DeleteEtudiant(Etudiant e)
		{
			//si l'objet personne est null, on renvoi une exception
			if (e == null)
			{
				throw new ArgumentNullException(nameof(e));
			}
			// on met à jour le context
			_context.Etudiants.Remove(e);
			_context.SaveChanges();
		}

		public IEnumerable<Etudiant> GetAllEtudiants()
		{
			return _context.Etudiants.Include("Inscriptions.LeCours").ToList();
		}

		public Etudiant GetEtudiantById(int id)
		{
			return _context.Etudiants.Include("Inscriptions.LeCours").FirstOrDefault(p => p.IdEtudiants == id);
		}

		public void UpdateEtudiant(Etudiant e)
		{
			_context.SaveChanges();
		}
	}
}
