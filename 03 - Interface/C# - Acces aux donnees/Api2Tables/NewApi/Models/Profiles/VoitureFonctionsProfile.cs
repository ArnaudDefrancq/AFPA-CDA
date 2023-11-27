﻿using AutoMapper;
using NewApi.Models.Data;
using NewApi.Models.Dtos;

namespace NewApi.Models.Profiles
{
	public class VoitureFonctionsProfile : Profile
	{
		protected VoitureFonctionsProfile()
		{
			CreateMap<Voiturefonction, VoituresFonctionsDto>();
			CreateMap<VoituresFonctionsDto, Voiturefonction>();
		}
	}
}
