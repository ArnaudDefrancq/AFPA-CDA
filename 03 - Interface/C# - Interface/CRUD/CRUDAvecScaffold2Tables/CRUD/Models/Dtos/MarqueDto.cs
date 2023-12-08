using System.Collections.Generic;

namespace CRUD.Models.Dtos
{
	public class MarqueDtoSansModel
	{
		public int IdMarque { get; set; }

		public string Libelle { get; set; } = null!;
	}
	public class MarqueDtoAvecModel
	{
		public MarqueDtoAvecModel(int idMarque, string libelle, ICollection<ModelDtoSansMarque> modeles)
		{
			IdMarque = idMarque;
			Libelle = libelle;
			Modeles = modeles;
		}

		public int IdMarque { get; set; }

		public string Libelle { get; set; } = null!;

		public virtual ICollection<ModelDtoSansMarque> Modeles { get; set; } = new List<ModelDtoSansMarque>();
	}
}
