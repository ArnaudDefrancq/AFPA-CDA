using AutoMapper;
using NewApi.Models.Data;
using NewApi.Models.Dtos;

namespace NewApi.Models.Profiles
{
	public class EmployesProfile : Profile
	{
		public EmployesProfile()
		{
			CreateMap<Employe, EmployesDto>();
			CreateMap<EmployesDto, Employe>();

			CreateMap<Employe, EmployesDtoTest>();
			CreateMap<EmployesDtoTest, Employe>();
		}
	}
}
