using AutoMapper;
using CRUD.Models.Data;
using CRUD.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Models.Profiles
{
	class MarqueProfile : Profile
	{
		public MarqueProfile()
		{
			CreateMap<Marque, MarqueDtoAvecModel>();
			CreateMap<MarqueDtoAvecModel, MarqueDtoAvecModel>();

			CreateMap<Marque, MarqueDtoSansModel>();
			CreateMap<MarqueDtoSansModel, Marque>();
		}
	}
}
