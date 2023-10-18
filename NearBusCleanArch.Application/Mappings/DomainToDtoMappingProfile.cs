using AutoMapper;
using NearBusCleanArch.Application.DTOs;
using NearBusCleanArch.Domain.Entities;

namespace NearBusCleanArch.Application.Mappings;

public class DomainToDtoMappingProfile : Profile
{
    public DomainToDtoMappingProfile()
    {
        CreateMap<Adress, AdressDTO>().ReverseMap();
        CreateMap<Companie, CompanieDTO>().ReverseMap();
        CreateMap<Employee, EmployeeDTO>().ReverseMap();
        CreateMap<Route, RouteDTO>().ReverseMap();
    }
}