using Api.Models.Data;
using Api.Models.Dtos;
using AutoMapper;

namespace Api.Models.Profiles
{
	public class PrestationProfile : Profile
	{
		public PrestationProfile()
		{
			CreateMap<Prestation, PrestationDto>();
			CreateMap<PrestationDto, Prestation>();
		}
	}
}
