using NearBusCleanArch.Application.DTOs;

namespace NearBusCleanArch.Application.Interfaces;

public interface IRouteService
{
    Task<IEnumerable<RouteDTO>> GetRoutesByCompanieId(int? id);
    Task<RouteDTO> GetRouteById(int? id);
    Task Add(RouteDTO routeDto);
    Task Update(RouteDTO routeDto);
    Task Remove(int? id);
}