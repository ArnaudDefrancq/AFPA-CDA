using AutoMapper;
using CRUDOpt.Models.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CRUDOpt.Models.Profiles
{
	public class Profiles : Profile
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
	}
}

