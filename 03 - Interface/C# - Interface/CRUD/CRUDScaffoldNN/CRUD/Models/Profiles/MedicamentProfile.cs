using AutoMapper;
using CRUD.Models.Data;
using CRUD.Models.Dtos;

namespace CRUD.Models.Profiles
{
	public class MedicamentProfile : Profile
	{
		public MedicamentProfile()
		{
			CreateMap<Medicament, MedicamentDtoSansPrescription>();
			CreateMap<MedicamentDtoSansPrescription, Medicament>();
		}
	}
}
