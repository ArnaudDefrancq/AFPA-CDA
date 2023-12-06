using AutoMapper;
using CRUDOpt.Models.Data;
using CRUDOpt.Models.Dtos;
using CRUDOpt.Models.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CRUDOpt.Models.Profiles
{
	public class ClassProfiles : Profile
	{
		// Avec ces méthodes, on va pouvoir changer un objet de type Objet en un objet de type Article et inversement. Grace a ca, on est plus flexible. Il faut juste refaire un profile pour récup un liste du type que l'on souhaite
		public static List<Article> FromObjectToArticles(List<Object> liste)
		{
			string listeSerialize = JsonConvert.SerializeObject(liste);
			List<Article> articles = JsonConvert.DeserializeObject<List<Article>>(listeSerialize);
			return articles;
		}
		public static List<Object> FromArticlesToObject(List<Article> liste)
		{
			string listeSerialize = JsonConvert.SerializeObject(liste);
			List<Object> objs = JsonConvert.DeserializeObject<List<Object>>(listeSerialize);
			return objs;
		}

		// La même chose pour les categories
		public static List<Categorie> FromObjectToCategories(List<Object> liste)
		{
			string listeSerialize = JsonConvert.SerializeObject(liste);
			List<Categorie> categs = JsonConvert.DeserializeObject<List<Categorie>>(listeSerialize);
			return categs;
		}
		public static List<Object> FromObjectToObject(List<Categorie> liste)
		{
			string listeSerialize = JsonConvert.SerializeObject(liste);
			List<Object> objs = JsonConvert.DeserializeObject<List<Object>>(listeSerialize);
			return objs;
		}
		//Permet la creation d'une list articleDto avec des Artcile et des categories
		public static List<ArticleDto> FromArticleToArticleDto()
		{
			List<Categorie> listeCateg = CategorieService.GetAllCategories();
			List<Article> listeArt = ArticleService.GetAllArticles();

			List<ArticleDto> listArticleDto = new List<ArticleDto>();

			for (int i = 0; i < listeArt.Count; i++)
			{
				for (int j = 0; j < listeCateg.Count; j++)
				{
					if (listeArt[i].IdCategorie == listeCateg[j].IdCategorie)
					{
						ArticleDto articleDto = new ArticleDto(listeArt[i].IdArticle, listeArt[i].LibelleArticle, listeArt[i].Quantite, listeArt[i].PrixUnitaire, listeArt[i].NumeroArticle, listeCateg[j].LibelleCategorie);

						listArticleDto.Add(articleDto);
					}
				}
			}
			return listArticleDto;
		}
	}
}

