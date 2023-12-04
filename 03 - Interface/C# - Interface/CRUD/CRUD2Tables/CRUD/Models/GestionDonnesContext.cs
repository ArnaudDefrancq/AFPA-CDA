using CRUD.Models.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Models
{
	public class GestionDonnesContext
	{
		public List<Article> ListArticles { get; set; }
		public List<Categorie> ListCategories { get; set; }
		public static string PathArticle { get; } = "U:\\59011-82-04\\AFPA-CDA\\03 - Interface\\C# - Interface\\CRUD\\CRUD2Tables\\CRUD\\JSON\\ArticleJSON.json";
		public static string PathCategorie { get; } = "U:\\59011-82-04\\AFPA-CDA\\03 - Interface\\C# - Interface\\CRUD\\CRUD2Tables\\CRUD\\JSON\\CategorieJSON.json";

		public GestionDonnesContext(List<Article> listArticles, List<Categorie> listCategories)
		{
			ListArticles = listArticles;
			ListCategories = listCategories;
		}

		public GestionDonnesContext()
		{

		}

		//************************************************//
		// Permet de créer les fichiers JSON article et categorie
		public void UploaderDonnees()
		{
			try
			{
				string jsonArticle = System.Text.Json.JsonSerializer.Serialize(ListArticles);
				string jsonCategorie = System.Text.Json.JsonSerializer.Serialize(ListCategories);

				File.WriteAllText(PathArticle, jsonArticle);
				File.WriteAllText(PathCategorie, jsonCategorie);

			}
			catch (Exception ex)
			{
				Console.WriteLine($"Une erreur s'est produite lors de la création du fichier JSON : {ex.Message}");
			}
		}

		//************************************************//
		// Permet de récup les données du JSON article
		public List<Article> DownloaderDonneesArticleJSON()
		{
			List<Article> prod = new List<Article>();
			try
			{
				if (File.Exists(PathArticle))
				{
					string json = File.ReadAllText(PathArticle);
					return prod = System.Text.Json.JsonSerializer.Deserialize<List<Article>>(json)!;
				}

			}
			catch (Exception ex)
			{
				Console.WriteLine($"Une erreur s'est produite lors de la création du fichier JSON : {ex.Message}");
			}

			return prod;
		}

		// Permet de récup les données du JSON categorie
		public List<Categorie> DownloaderDonneesCategorieJSON()
		{
			List<Categorie> prod = new List<Categorie>();
			try
			{
				if (File.Exists(PathCategorie))
				{
					string json = File.ReadAllText(PathCategorie);
					return prod = System.Text.Json.JsonSerializer.Deserialize<List<Categorie>>(json)!;
				}

			}
			catch (Exception ex)
			{
				Console.WriteLine($"Une erreur s'est produite lors de la création du fichier JSON : {ex.Message}");
			}

			return prod;
		}

		//************************************************//

	}
}
