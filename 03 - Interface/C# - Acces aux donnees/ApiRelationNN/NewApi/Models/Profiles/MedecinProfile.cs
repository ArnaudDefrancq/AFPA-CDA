using AutoMapper;
using NewApi.Models.Data;
using NewApi.Models.Dtos;

namespace NewApi.Models.Profiles
{
	public class MedecinProfile : Profile
	{
		public MedecinProfile()
		{
			CreateMap<Medecin, MedecinDto>();
			CreateMap<MedecinDto, Medecin>();
		}
	}
}
