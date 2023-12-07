namespace CRUD.Models.Dtos
{
	public class ModelDtoSansMarque
	{
		public int IdModele { get; set; }

		public string? Libelle { get; set; }

		public int MarqueId { get; set; }
	}

	public class ModelDtoAvecMarque
	{
		public int IdModele { get; set; }

		public string? Libelle { get; set; }

		public int MarqueId { get; set; }

		public virtual MarqueDtoSansModel Marque { get; set; } = null!;
	}


}
