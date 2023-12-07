using AutoMapper;
using CRUD.Models.Data;
using CRUD.Models.Dtos;

namespace CRUD.Models.Profiles
{
	class ModelProfile : Profile
	{
		public ModelProfile()
		{
			CreateMap<Modele, ModelDtoAvecMarque>();
			CreateMap<ModelDtoAvecMarque, Modele>();

			CreateMap<Modele, ModelDtoSansMarque>();
			CreateMap<ModelDtoSansMarque, Modele>();
		}
	}
}
