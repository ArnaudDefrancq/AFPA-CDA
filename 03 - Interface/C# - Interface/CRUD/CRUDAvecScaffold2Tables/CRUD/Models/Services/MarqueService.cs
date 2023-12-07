using CRUD.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUD.Models.Services
{
	public class MarqueService
	{
		private readonly voitureDBContext _context;
		public MarqueService(voitureDBContext context)
		{
			_context = context;
		}

		public void AddMarque(Marque mq)
		{
			if (mq == null)
			{
				throw new ArgumentNullException(nameof(mq));
			}
			_context.Marques.Add(mq);
			_context.SaveChanges();
		}

		public void DeleteMarque(Marque mq)
		{
			//si l'objet personne est null, on renvoi une exception
			if (mq == null)
			{
				throw new ArgumentNullException(nameof(mq));
			}
			// on met à jour le context
			_context.Marques.Remove(mq);
			_context.SaveChanges();
		}

		public IEnumerable<Marque> GetAllMarques()
		{
			return _context.Marques.ToList();
		}

		public Marque GetMarqueById(int id)
		{
			return _context.Marques.FirstOrDefault(p => p.IdMarque == id);
		}

		public void UpdateMarque(Marque mq)
		{
			_context.SaveChanges();
		}
	}
}
