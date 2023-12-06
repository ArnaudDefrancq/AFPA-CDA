using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDVoitureDb.Models.Dtos
{
	public class VoitureDto
	{
		public string? Marque { get; set; }

		public string? Model { get; set; }

		public int? Km { get; set; }

		public VoitureDto(string? marque, string? model, int? km)
		{
			Marque = marque;
			Model = model;
			Km = km;
		}

	}
}
