using AutoMapper;
using NewApi.Models.Data;
using NewApi.Models.Dtos;

namespace NewApi.Models.Profiles
{
	public class VoitureFonctionsProfile : Profile
	{
		public VoitureFonctionsProfile()
		{
			CreateMap<Voiturefonction, VoituresFonctionsDto>();
			CreateMap<VoituresFonctionsDto, Voiturefonction>();

			CreateMap<Voiturefonction, VoituresFonctionsDtoTest>();
			CreateMap<VoituresFonctionsDtoTest, Voiturefonction>();

			CreateMap<Voiturefonction, VoituresFonctionsDto2>();
			CreateMap<VoituresFonctionsDto2, Voiturefonction>();
		}
	}
}
