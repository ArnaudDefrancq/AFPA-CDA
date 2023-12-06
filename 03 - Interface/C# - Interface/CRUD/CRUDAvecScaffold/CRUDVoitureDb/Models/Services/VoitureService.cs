using CRUDVoitureDb.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUDVoitureDb.Models.Services
{
	public class VoitureService
	{
		private readonly VoitureDBContext _context;
		public VoitureService(VoitureDBContext context)
		{
			_context = context;
		}

		public void AddVoiture(Voiture v)
		{
			if (v == null)
			{
				throw new ArgumentNullException(nameof(v));
			}
			_context.Voitures.Add(v);
			_context.SaveChanges();
		}

		public void DeleteVoiture(Voiture v)
		{
			//si l'objet personne est null, on renvoi une exception
			if (v == null)
			{
				throw new ArgumentNullException(nameof(v));
			}
			// on met à jour le context
			_context.Voitures.Remove(v);
			_context.SaveChanges();
		}

		public IEnumerable<Voiture> GetAllVoitures()
		{
			return _context.Voitures.ToList();
		}

		public Voiture GetVoitureById(int id)
		{
			return _context.Voitures.FirstOrDefault(p => p.IdVoiture == id);
		}

		public void UpdateVoiture(Voiture v)
		{
			_context.SaveChanges();
		}
	}
}
