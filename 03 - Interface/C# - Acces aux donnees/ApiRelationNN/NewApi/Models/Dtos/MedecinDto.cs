﻿using NewApi.Models.Data;

namespace NewApi.Models.Dtos
{
	public class MedecinDto
	{
		public string Nom { get; set; } = null!;

		public string Prenom { get; set; } = null!;

		public int? Age { get; set; }

		public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
	}
}
