using CRUD.Helpers;
using CRUD.Models.Data;
using Newtonsoft.Json;
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

		//public static string PathArticle { get; } = "C:\\Users\\Toyger\\OneDrive\\Bureau\\Git AFPA\\AFPA-CDA\\03 - Interface\\C# - Interface\\CRUD\\CRUD2Tables\\CRUD\\JSON\\ArticleJSON.json"; // Maison
		//public static string PathCategorie { get; } = "C:\\Users\\Toyger\\OneDrive\\Bureau\\Git AFPA\\AFPA-CDA\\03 - Interface\\C# - Interface\\CRUD\\CRUD2Tables\\CRUD\\JSON\\CategorieJSON.json"; // Maison


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
					prod = System.Text.Json.JsonSerializer.Deserialize<List<Article>>(json);
					return prod;
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
		// Permet d'ajouter un article dans un JSON
		public void AjouterDonneeArticleJSON(Article a)
		{
			List<Article> prod = DownloaderDonneesArticleJSON();
			prod.Add(a);

			string json = JsonConvert.SerializeObject(prod);

			File.WriteAllText(PathArticle, json);
		}

		//************************************************//
		// Permet de supprimer un article dans un JSON
		public void SupprimerDonneeArticleJson(Article a)
		{
			List<Article> prod = DownloaderDonneesArticleJSON();
			List<Article> cloneProd = new List<Article>(prod);

			foreach (Article item in cloneProd)
			{
				if (item.IdArticle == a.IdArticle)
				{
					prod.Remove(item);
				}
			}
			String json = JsonConvert.SerializeObject(prod);
			File.WriteAllText(PathArticle, json);
		}

		//************************************************//
		// Permet de modifier un article dans un JSON
		public void UpdateDonneeArticleJson(Article a)
		{
			List<Article> prod = DownloaderDonneesArticleJSON();

			foreach (Article item in prod)
			{
				if (item.IdArticle == a.IdArticle)
				{
					item.LibelleArticle = a.LibelleArticle;
					item.Quantite = a.Quantite;
					item.PrixUnitaire = a.PrixUnitaire;
					item.MontantTotal = a.MontantTotal;
					item.IdCategorie = a.IdCategorie;
				}
			}
			String json = JsonConvert.SerializeObject(prod);
			File.WriteAllText(PathArticle, json);
		}

		//************************************************//
		// Permet d'ajouter une categorie dans un JSON
		public void AjouterDonneeCategorieJSON(Categorie c)
		{
			List<Categorie> prod = DownloaderDonneesCategorieJSON();
			prod.Add(c);

			string json = JsonConvert.SerializeObject(prod);

			File.WriteAllText(PathCategorie, json);
		}

		//************************************************//
		// Permet de supprimer une categorie dans un JSON
		public void SupprimerDonneeCategorieJson(Categorie c)
		{
			List<Categorie> prod = DownloaderDonneesCategorieJSON();
			List<Categorie> cloneProd = new List<Categorie>(prod);

			foreach (Categorie item in cloneProd)
			{
				if (item.IdCategorie == c.IdCategorie)
				{
					prod.Remove(item);
				}
			}
			String json = JsonConvert.SerializeObject(prod);
			File.WriteAllText(PathCategorie, json);
		}

		//************************************************//
		// Permet de modifier un article dans un JSON
		public void UpdateDonneeCategorieJson(Categorie c)
		{
			List<Categorie> prod = DownloaderDonneesCategorieJSON();

			foreach (Categorie item in prod)
			{
				if (item.IdCategorie == c.IdCategorie)
				{
					item.LibelleCategorie = c.LibelleCategorie;
				}
			}
			String json = JsonConvert.SerializeObject(prod);
			File.WriteAllText(PathCategorie, json);
		}

	}
}
