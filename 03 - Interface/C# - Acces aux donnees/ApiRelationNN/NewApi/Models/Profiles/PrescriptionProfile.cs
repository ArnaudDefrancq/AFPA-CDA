﻿using AutoMapper;
using NewApi.Models.Data;
using NewApi.Models.Dtos;

namespace NewApi.Models.Profiles
{
	public class PrescriptionProfile : Profile
	{
		public PrescriptionProfile()
		{
			CreateMap<Prescription, PrescriptionDto>();
			CreateMap<PrescriptionDto, Prescription>();

			CreateMap<Prescription, PrescriptionDtoGetMedecin>();
			CreateMap<PrescriptionDtoGetMedecin, Prescription>();

			CreateMap<Prescription, PrescriptionDtoGetMedicament>();
			CreateMap<PrescriptionDtoGetMedicament, Prescription>();
		}
	}
}
