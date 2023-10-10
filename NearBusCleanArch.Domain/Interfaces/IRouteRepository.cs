using NearBusCleanArch.Domain.Entities;

namespace NearBusCleanArch.Domain.Interfaces;

public interface IRouteRepository
{
    Task<IEnumerable<Route>> GetRoutesByCompanieId(int? id);
    Task<Route> GetRouteById(int? id);
    Task<Route> Create(Route route);
    Task<Route> Update(Route route);
    Task<Route> Remove(Route route);
}