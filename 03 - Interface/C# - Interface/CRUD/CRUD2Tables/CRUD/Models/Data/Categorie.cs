namespace CRUD.Models.Data
{
	public class Categorie
	{
		public int IdCategorie { get; set; }
		public string LibelleCategorie { get; set; }
		public static int Compteur { get; set; } = 0;

		public Categorie(string libelleCategorie)
		{
			IdCategorie = ++Compteur;
			LibelleCategorie = libelleCategorie;
		}
	}
}
