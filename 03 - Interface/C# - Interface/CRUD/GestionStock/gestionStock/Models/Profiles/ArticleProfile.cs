using AutoMapper;
using gestionStock.Models.Data;
using gestionStock.Models.Dtos;

namespace gestionStock.Models.Profiles
{
	public class ArticleProfile : Profile
	{
		public ArticleProfile()
		{
			CreateMap<Article, ArticleDtoIn>();
			CreateMap<ArticleDtoIn, Article>();

			CreateMap<Article, ArticleDtoSansCategorie>();
			CreateMap<ArticleDtoSansCategorie, Article>();

			CreateMap<Article, ArticleDtoOutAplatie>()
				.ForMember(ap => ap.LibelleCategorie, o => o.MapFrom(a => a.LaCategorie.LibelleCategorie))
				.ForMember(ap => ap.LibelleTypeProduit, o => o.MapFrom(a => a.LaCategorie.LeTypeProduit.LibelleTypeProduit));
			CreateMap<ArticleDtoOutAplatie, Article>();
		}
	}
}
