using AutoMapper;
using CRUD.Models.Data;
using CRUD.Models.Dtos;

namespace CRUD.Models.Profiles
{
	public class AppartementProfile : Profile
	{
		public AppartementProfile() {
			CreateMap<Appartement, AppartementDtoIn>();
			CreateMap<AppartementDtoIn, Appartement>();

			CreateMap<Appartement, AppartementDtoApplatieAvecCategorie>().ForMember(ap => ap.TypeAppartement, o => o.MapFrom(a => a.CategorieAppartement.TypeAppartement));
			CreateMap<AppartementDtoApplatieAvecCategorie, Appartement>();
		}
	}
}
