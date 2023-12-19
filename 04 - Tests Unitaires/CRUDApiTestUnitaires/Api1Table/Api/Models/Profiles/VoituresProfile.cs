using Api.Models.Data;
using Api.Models.DTOs;
using AutoMapper;

namespace Api.Models.Profiles
{
	public class VoituresProfile : Profile
	{
		public VoituresProfile()
		{
			CreateMap<Voiture, VoituresDto>();
			CreateMap<VoituresDto, Voiture>();
		}
	}
}
