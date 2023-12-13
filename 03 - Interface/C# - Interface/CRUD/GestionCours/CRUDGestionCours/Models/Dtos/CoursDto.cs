using CRUDGestionCours.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDGestionCours.Models.Dtos
{
	public class CoursDtoIn
	{
		public string? Nom { get; set; }

		public string? Description { get; set; }
	}

	public class CoursDtoOutAplatie
	{
		public int IdCours { get; set; }

		public string? Nom { get; set; }

		public string? Description { get; set; }

		public virtual List<InscriptionDtoSansCours> ListEtudiantInscrit { get; set; } = new List<InscriptionDtoSansCours>();
	}

	public class CoursDtoOutSansInscription
	{
		public int IdCours { get; set; }

		public string? Nom { get; set; }

		public string? Description { get; set; }
	}
}
