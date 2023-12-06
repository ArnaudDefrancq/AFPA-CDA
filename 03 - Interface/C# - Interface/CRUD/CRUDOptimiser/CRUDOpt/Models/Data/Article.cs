using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOpt.Models.Data
{
	public class Article
	{
		public int IdArticle { get; set; }
		public string LibelleArticle { get; set; }
		public int NumeroArticle { get; set; }
		public int Quantite { get; set; }
		public int PrixUnitaire { get; set; }

		public Article()
		{
		}

		public Article(int idArticle, string libelleArticle, int numeroArtcile, int quantite, int prixUnitaire)
		{
			IdArticle = idArticle;
			LibelleArticle = libelleArticle;
			NumeroArticle = numeroArtcile;
			Quantite = quantite;
			PrixUnitaire = prixUnitaire;
		}
	}
}
