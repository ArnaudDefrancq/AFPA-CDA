using CRUDGestionCours.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDGestionCours.Models.Dtos
{
	public class EtudiantDtoIn
	{
		public string? Nom { get; set; }

		public string? Prenom { get; set; }

		public int? Age { get; set; }

		public EtudiantDtoIn(string? nom, string? prenom, int? age)
		{
			Nom = nom;
			Prenom = prenom;
			Age = age;
		}
	}

	public class EtudiantDtoOutSansInscription
	{
		public int IdEtudiants { get; set; }

		public string? Nom { get; set; }

		public string? Prenom { get; set; }

		public int? Age { get; set; }
	}

	public class EtudiantDtoOutAplatie
	{
		public int IdEtudiants { get; set; }

		public string? Nom { get; set; }

		public string? Prenom { get; set; }

		public int? Age { get; set; }

		public virtual List<InscriptionDtoSansEtudiant> Inscriptions { get; set; } = new List<InscriptionDtoSansEtudiant>();
	}
}
