using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.Models.Data;

namespace CRUD.Models.Services
{
	public class ModelService
	{
		private readonly voitureDBContext _context;
		public ModelService(voitureDBContext context)
		{
			_context = context;
		}

		public void AddModel(Modele md)
		{
			if (md == null)
			{
				throw new ArgumentNullException(nameof(md));
			}
			_context.Modeles.Add(md);
			_context.SaveChanges();
		}

		public void DeleteModel(Modele md)
		{
			//si l'objet personne est null, on renvoi une exception
			if (md == null)
			{
				throw new ArgumentNullException(nameof(md));
			}
			// on met à jour le context
			_context.Modeles.Remove(md);
			_context.SaveChanges();
		}

		public IEnumerable<Modele> GetAllModels()
		{
			return _context.Modeles.ToList();
		}

		public Modele GetModelById(int id)
		{
			return _context.Modeles.FirstOrDefault(p => p.IdModele == id);
		}

		public void UpdateModel(Modele md)
		{
			_context.SaveChanges();
		}
	}
}
