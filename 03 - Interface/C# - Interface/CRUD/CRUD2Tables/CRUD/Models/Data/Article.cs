﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Models.Data
{
	public class Article
	{
		public int IdArticle { get; set; }
		public string LibelleArticle { get; set; }
		public int Quantite { get; set; }
		public int PrixUnitaire { get; set; }
		public int MontantTotal { get; set; }
		public string LabelleCategorie { get; set; }
		public static int Compteur { get; set; } = 0;

		public Article(string libelleArticle, int quantite, int prixUnitaire, string labelleCategorie)
		{
			IdArticle = ++Compteur;
			LibelleArticle = libelleArticle;
			Quantite = quantite;
			PrixUnitaire = prixUnitaire;
			MontantTotal = PrixUnitaire * Quantite;
			LabelleCategorie = labelleCategorie;
		}

		public Article()
		{
		}

		public Article(int idArticle, string libelleArticle, int quantite, int prixUnitaire, int montantTotal, string labelleCategorie)
		{
			IdArticle = idArticle;
			LibelleArticle = libelleArticle;
			Quantite = quantite;
			PrixUnitaire = prixUnitaire;
			MontantTotal = montantTotal;
			LabelleCategorie = labelleCategorie;
		}
	}
}
