using AutoMapper;
using gestionStock.Models.Data;
using gestionStock.Models.Dtos;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace gestionStock.Models.Profiles
{
	public class CategorieProfile : Profile
	{
		public CategorieProfile()
		{
			CreateMap<Categorie, CategorieDtoIn>();
			CreateMap<CategorieDtoIn, Categorie>();

			CreateMap<Categorie, CategorieDtoSansType>();
			CreateMap<CategorieDtoSansType, Categorie>();


			CreateMap<Categorie, CategorieDtoAplatie>()
				.ForMember(cd => cd.ListArticles, o => o.MapFrom(c => c.LesArticles))
				.ForMember(cp => cp.LibelleTypeProduit, o => o.MapFrom(c => c.LeTypeProduit.LibelleTypeProduit));

			CreateMap<CategorieDtoAplatie, Categorie>();
		}
	}
}
