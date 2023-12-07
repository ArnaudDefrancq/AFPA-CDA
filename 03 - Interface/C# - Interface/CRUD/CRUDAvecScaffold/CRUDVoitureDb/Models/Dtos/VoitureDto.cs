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

		public VoitureDto()
		{
		}
	}
}
