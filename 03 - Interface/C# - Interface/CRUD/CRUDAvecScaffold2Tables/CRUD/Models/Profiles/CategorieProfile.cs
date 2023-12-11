using AutoMapper;
using CRUD.Models.Data;
using CRUD.Models.Dtos;

namespace CRUD.Models.Profiles
{
	public class CategorieProfile : Profile
	{
		public CategorieProfile()
		{
			CreateMap<Categorie, CategorieDtoOutAvecAppartement>();
			CreateMap<CategorieDtoOutAvecAppartement, Categorie>();

			CreateMap<Categorie, CategorieDtoIn>();
			CreateMap<CategorieDtoIn, Categorie>();

			CreateMap<Categorie, CategorieDtoOutSansAppartement>();
			CreateMap<CategorieDtoOutSansAppartement, Categorie>();
		}
	}
}
