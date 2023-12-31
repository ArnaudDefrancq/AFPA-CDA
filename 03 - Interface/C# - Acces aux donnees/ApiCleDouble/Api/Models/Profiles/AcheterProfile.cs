﻿using Api.Models.Data;
using Api.Models.Dtos;
using AutoMapper;

namespace Api.Models.Profiles
{
	public class AcheterProfile : Profile
	{
		public AcheterProfile()
		{
			CreateMap<Acheter, AcheterDto>();
			CreateMap<AcheterDto, Acheter>();
		}
	}
}
