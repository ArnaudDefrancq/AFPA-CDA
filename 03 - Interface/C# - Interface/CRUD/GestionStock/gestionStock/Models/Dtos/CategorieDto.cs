﻿using System.Collections.Generic;


namespace gestionStock.Models.Dtos
{
	public class CategorieDtoIn
	{

		public string? LibelleCategorie { get; set; }

		public int IdTypeProduit { get; set; }

		public CategorieDtoIn(string? libelleCategorie, int idTypeProduit)
		{
			LibelleCategorie = libelleCategorie;
			IdTypeProduit = idTypeProduit;
		}
	}

	public class CategorieDtoSansType
	{
		public int IdCategorie { get; set; }

		public string? LibelleCategorie { get; set; }

		public int IdTypeProduit { get; set; }

		public virtual List<ArticleDtoSansCategorie> LesArticles { get; set; } = new List<ArticleDtoSansCategorie>();
	}

	public class CategorieDtoAplatie
	{
		public int IdCategorie { get; set; }

		public string? LibelleCategorie { get; set; }

		public int IdTypeProduit { get; set; }

		public virtual List<ArticleDtoSansCategorie> ListArticles { get; set; } = new List<ArticleDtoSansCategorie>();

		public string LibelleTypeProduit { get; set; }
	}
}
