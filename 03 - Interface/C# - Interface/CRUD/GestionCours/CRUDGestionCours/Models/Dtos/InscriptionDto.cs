using CRUDGestionCours.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDGestionCours.Models.Dtos
{
	public class InscriptionDtoIn
	{
		public int? Etudiant { get; set; }

		public int? Cours { get; set; }

		public DateTime? DateInscription { get; set; }
	}

	public class InscriptionDtoSansCours
	{
		public int IdInscriptions { get; set; }

		public int? Etudiant { get; set; }

		public int? Cours { get; set; }

		public DateTime? DateInscription { get; set; }

		public virtual EtudiantDtoOutSansInscription? LeEtudiant { get; set; }
	}
	public class InscriptionDtoSansEtudiant
	{
		public int IdInscriptions { get; set; }

		public int? Etudiant { get; set; }

		public int? Cours { get; set; }

		public DateTime? DateInscription { get; set; }

		public virtual CoursDtoOutSansInscription? LeCours { get; set; }
	}

	public class InscriptionDtoOutAplatie
	{
		public int IdInscriptions { get; set; }

		public int? Etudiant { get; set; }

		public int? Cours { get; set; }

		public DateTime? DateInscription { get; set; }

		public string? NomCours { get; set; }

		public string DescriptionCours { get; set; }

		public string? NomEtudiant { get; set; }

		public string? PrenomEtudiant { get; set; }
	}

}
