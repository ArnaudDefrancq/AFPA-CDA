using Api.Data.DTO;
using Api.Data.Models;
using AutoMapper;

namespace Api.Data.Profiles
{
	public class EmployesProfile : Profile
	{
		protected EmployesProfile()
		{
			CreateMap<Employe, EmployeDTO>();
			CreateMap<EmployeDTO, Employe>();
		}
	}
}
