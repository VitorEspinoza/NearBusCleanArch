using AutoMapper;
using NearBusCleanArch.Application.DTOs;
using NearBusCleanArch.Domain.Entities;

namespace NearBusCleanArch.Application.Mappings;

public class DomainToDtoMappingProfile : Profile
{
    public DomainToDtoMappingProfile()
    {
        CreateMap<string, System.TimeOnly>().ConvertUsing(s => System.TimeOnly.Parse(s));
       
        CreateMap<Adress, AdressDTO>().ReverseMap();
        CreateMap<Companie, CompanieDTO>().ReverseMap();
        CreateMap<Employee, EmployeeDTO>().ReverseMap();
        CreateMap<Route, RouteDTO>().ReverseMap();
        CreateMap<Route, RouteCreateDTO>().ReverseMap();
        
    }
}