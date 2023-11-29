using Api.Models.Data;
using Api.Models.Dtos;
using AutoMapper;

namespace Api.Models.Profiles
{
	public class EnfantProfile : Profile
	{
		public EnfantProfile()
		{
			CreateMap<Enfant, EnfantDto>();
			CreateMap<EnfantDto, Enfant>();
		}
	}
}
