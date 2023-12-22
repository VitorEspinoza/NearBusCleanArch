using NearBusCleanArch.Application.DTOs;

namespace NearBusCleanArch.Application.Interfaces;

public interface IRouteService
{
    Task<IEnumerable<RouteDTO>> GetRoutesByCompanieId(int? id);
    Task<RouteDTO> GetRouteById(int? id);
    Task Add(RouteCreateDTO routeDto);
    Task Update(RouteCreateDTO routeDto);
    Task Remove(int? id);
}