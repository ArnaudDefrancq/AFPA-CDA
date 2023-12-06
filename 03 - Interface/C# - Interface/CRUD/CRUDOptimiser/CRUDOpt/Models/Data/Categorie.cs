namespace CRUDOpt.Models.Data
{
	public class Categorie
	{
		public int IdCategorie { get; set; }
		public string LibelleCategorie { get; set; }

		public Categorie()
		{
		}

		public Categorie(int idCategorie, string libelleCategorie)
		{
			IdCategorie = idCategorie;
			LibelleCategorie = libelleCategorie;
		}
	}
}
