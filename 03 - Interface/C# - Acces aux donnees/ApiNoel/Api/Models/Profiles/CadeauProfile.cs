using Api.Models.Data;
using Api.Models.Dtos;
using AutoMapper;

namespace Api.Models.Profiles
{
	public class CadeauProfile : Profile
	{
		public CadeauProfile()
		{
			CreateMap<Cadeau, CadeauDto>();
			CreateMap<CadeauDto, Cadeau>();
		}
	}
}
