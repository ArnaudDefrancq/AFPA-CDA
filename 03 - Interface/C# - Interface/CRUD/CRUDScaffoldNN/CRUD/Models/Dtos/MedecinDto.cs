using CRUD.Models.Data;
using System.Collections.Generic;

namespace CRUD.Models.Dtos
{
	public class MedecinDtoSansPrescriptions
	{
		public string Nom { get; set; } = null!;

		public string Prenom { get; set; } = null!;

		public int? Age { get; set; }
	}

}
