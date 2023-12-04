using CRUD.Models.Data;
using System.Collections.Generic;

namespace CRUD.Models.Services
{
	public class ArticleService
	{
		public ArticleService()
		{
		}

		public void AddArticle(Article a)
		{
			GestionDonnesContext context = new GestionDonnesContext();
			context.AjouterDonneeArticleJSON(a);
		}

		public void DeleteArticle(Article a)
		{
			GestionDonnesContext context = new GestionDonnesContext();
			context.SupprimerDonneeArticleJson(a);
		}

		public List<Article> GetAllArticles()
		{
			GestionDonnesContext context = new GestionDonnesContext();
			List<Article> a = context.DownloaderDonneesArticleJSON();
			return a;
		}

		public void GetProduitById()
		{

		}

		public void UpdateArticle(Article a)
		{
			GestionDonnesContext context = new GestionDonnesContext();
			context.UpdateDonneeArticleJson(a);
		}

	}
}
