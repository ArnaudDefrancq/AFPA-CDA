using AutoMapper;
using CRUD.Models.Data;
using CRUD.Models.Dtos;

namespace CRUD.Models.Profiles
{
	public class MedecinProfile : Profile
	{
		public MedecinProfile()
		{
			CreateMap<Medecin, MedecinDtoSansPrescriptions>();
			CreateMap<MedecinDtoSansPrescriptions, Medecin>();
		}
	}
}
