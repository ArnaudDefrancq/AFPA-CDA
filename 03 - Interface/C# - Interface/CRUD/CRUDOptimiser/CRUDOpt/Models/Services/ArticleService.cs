using CRUDOpt.Models.Data;
using CRUDOpt.Models.Profiles;
using System.Collections.Generic;


namespace CRUDOpt.Models.Services
{
	public class ArticleService
	{
		// Le path est dans le service car c'est dans le service où l'on décide où l'on envoie les données
		static public string Path { get; set; } = "../../../JSON/Articles.json";
		// Ici c'est le prochain ID pour quand on ajoute un nouvelle article
		static public int NextId { get; set; }

		// On récupère tous les Artciles dans le JSON
		static public List<Article> GetAllArticles()
		{
			StructureJson sj = ArticleDAO.LireFichier(Path);
			List<Article> liste = ClassProfiles.FromObjectToArticles(sj.Liste);
			NextId = sj.NextId;

			return liste;
		}

		// methode qui met à jour le fichier avec les produits 
		static public void SaveArticles(List<Article> liste)
		{
			StructureJson sj = new StructureJson();
			sj.Liste = ClassProfiles.FromArticlesToObject(liste);
			sj.NextId = NextId;
			ArticleDAO.EcrireDansJSON(sj, Path); //enregistrer fichier
		}

		static public Article GetById(int idArticle)
		//Méthode qui permet de modifier un enregistrement
		{
			List<Article> liste = GetAllArticles();
			// on recherche la position du produit dans la liste
			Article p = liste.Find(r => r.IdArticle == idArticle);
			return p;
		}

		static public void AddArticle(Article a)
		//Méthode qui permet d'entrer un enregistrement
		{
			List<Article> liste = GetAllArticles();
			// On change l'IdArticle
			a.IdArticle = NextId++;
			// on ajoute l'enregistrement
			liste.Add(a);
			SaveArticles(liste);
		}

		static public void UpdateArticle(Article a)
		//Méthode qui permet de modifier un enregistrement
		{
			List<Article> liste = GetAllArticles();
			// on recherche la position du produit dans la liste
			int position = liste.FindIndex(r => r.IdArticle == a.IdArticle);
			// on met à jour le produit dans la liste
			liste[position].NumeroArticle = a.NumeroArticle;
			liste[position].LibelleArticle = a.LibelleArticle;
			liste[position].Quantite = a.Quantite;
			// on sauvegarde dans le fichier
			SaveArticles(liste);
		}

		static public void DeleteArticle(Article a)
		//Méthode qui permet de modifier un enregistrement
		{
			List<Article> liste = GetAllArticles();
			// on recherche la position du produit dans la liste
			liste.RemoveAll(x => x.IdArticle == a.IdArticle);
			// on sauvegarde dans le fichier
			SaveArticles(liste);
		}
	}
}
