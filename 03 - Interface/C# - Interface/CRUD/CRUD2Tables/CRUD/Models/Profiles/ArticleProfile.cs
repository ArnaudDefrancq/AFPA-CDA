﻿using CRUD.Helpers;
using CRUD.Models.Data;
using CRUD.Models.Dtos;
using System.Collections.Generic;

namespace CRUD.Models.Profiles
{
	public class ArticleProfile
	{
		public ArticleProfile()
		{
		}

		// Permet de tranformer une liste d'article en liste d'articleDto
		public List<ArticleDto> ArticlesToArticleDto()
		{
			// Récup de la liste des categories
			GestionDonnesContext contextCategorie = new GestionDonnesContext();
			List<Categorie> categories = contextCategorie.DownloaderDonneesCategorieJSON();

			// Récup de la liste des articles
			GestionDonnesContext contextArticle = new GestionDonnesContext();
			List<Article> articles = contextArticle.DownloaderDonneesArticleJSON();

			// Création de la liste des articleDto
			List<ArticleDto> listarticleDtos = new List<ArticleDto>() { };

			for (int i = 0; i < articles.Count; i++)
			{
				for (int j = 0; j < categories.Count; j++)
				{
					if (articles[i].IdCategorie == categories[j].IdCategorie)
					{
						ArticleDto articleDto = new ArticleDto(articles[i].IdArticle, articles[i].LibelleArticle, articles[i].Quantite, articles[i].PrixUnitaire, articles[i].MontantTotal, categories[j].LibelleCategorie);
						listarticleDtos.Add(articleDto);
					}
				}
			}
			return listarticleDtos;
		}

		// Permet de transformer un d'articleDto en article
		public Article ArticleDtoToArticle(ArticleDto aDto)
		{
			// Récup de la List des articles
			GestionDonnesContext contextArticle = new GestionDonnesContext();
			List<Article> articles = contextArticle.DownloaderDonneesArticleJSON();

			// Nouvelle objet
			Article art = new Article();

			foreach (Article article in articles)
			{
				if (article.IdArticle == aDto.IdArticle)
				{
					art = article;
				}
			}
			return art;
		}
	}
}