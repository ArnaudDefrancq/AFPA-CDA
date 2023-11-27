using Api.Data.DTO;
using Api.Data.Models;
using AutoMapper;

namespace Api.Data.Profiles
{
	public class VoitureFonctionsProfile : Profile
	{
		protected VoitureFonctionsProfile()
		{
			CreateMap<Voiturefonction, VoitureFonctionDTO>();
			CreateMap<VoitureFonctionDTO, Voiturefonction>();
		}
	}
}
