namespace CRUDVoitureDb.Models.Dtos
{
	public class VoitureDto
	{
		public int IdVoiture { get; set; }
		public string? Marque { get; set; }

		public string? Model { get; set; }

		public int? Km { get; set; }

		public VoitureDto(int idVoiture, string? marque, string? model, int? km)
		{
			IdVoiture = idVoiture;
			Marque = marque;
			Model = model;
			Km = km;
		}

		public VoitureDto()
		{
		}
	}
}
