using AutoMapper;
using CRUDVoitureDb.Models.Data;
using CRUDVoitureDb.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDVoitureDb.Models.Profiles
{
	public class VoitureProfile : Profile
	{
		public VoitureProfile()
		{
			CreateMap<Voiture, VoitureDto>();
			CreateMap<VoitureDto, Voiture>();
		}
	}

}

