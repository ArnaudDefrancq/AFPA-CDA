using AutoMapper;
using gestionStock.Models.Data;
using gestionStock.Models.Dtos;
using System.Linq;

namespace gestionStock.Models.Profiles
{
	public class CategorieProfile : Profile
	{
		public CategorieProfile()
		{
			CreateMap<Categorie, CategorieDtoIn>();
			CreateMap<CategorieDtoIn, Categorie>();

			CreateMap<Categorie, CategorieDtoSansArticleSansType>();
			CreateMap<CategorieDtoSansArticleSansType, Categorie>();

			CreateMap<Categorie, CategorieDtoAplatie>()
				.ForMember(cp => cp.LibelleArticle, o => o.MapFrom(c => c.LesArticles.Select(a => a.LibelleArticle)))
				.ForMember(cp => cp.LibelleTypeProduit, o => o.MapFrom(c => c.LeTypeProduit.LibelleTypeProduit));
			CreateMap<CategorieDtoAplatie, Categorie>();
		}
	}
}
