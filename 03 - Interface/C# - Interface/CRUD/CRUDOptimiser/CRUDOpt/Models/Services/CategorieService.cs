using CRUDOpt.Models.Data;
using CRUDOpt.Models.Profiles;
using System.Collections.Generic;


namespace CRUDOpt.Models.Services
{
	public class CategorieService
	{
		static public string Path { get; set; } = "../../../JSON/Categories.json";
		// Ici c'est le prochain ID pour quand on ajoute un nouvelle article
		static public int NextId { get; set; }

		static public List<Categorie> GetAllCategories()
		{
			StructureJson sj = ArticleDAO.LireFichier(Path);
			List<Categorie> liste = ClassProfiles.FromObjectToCategories(sj.Liste);
			NextId = sj.NextId;

			return liste;
		}
	}
}
