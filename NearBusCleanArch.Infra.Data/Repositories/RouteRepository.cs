using NearBusCleanArch.Domain.Entities;
using NearBusCleanArch.Domain.Interfaces;
using NearBusCleanArch.Infra.Data.Context;

namespace NearBusCleanArch.Infra.Data.Repositories;

public class RouteRepository : IRouteRepository
{
    private ApplicationDbContext _routeContext;

    public RouteRepository(ApplicationDbContext context)
    {
        _routeContext = context;
    }
    public async Task<IEnumerable<Route>> GetRoutesByCompanieId(int? id)
    {
        throw new NotImplementedException();
    }

    public async Task<Route> GetRouteById(int? id)
    {
        throw new NotImplementedException();
    }

    public async Task<Route> Create(Route route)
    {
        _routeContext.Add(route);
        await _routeContext.SaveChangesAsync();
        return route;
    }

    public async Task<Route> Update(Route route)
    {
        _routeContext.Update(route);
        await _routeContext.SaveChangesAsync();
        return route;
    }

    public async Task<Route> Remove(Route route)
    {
        _routeContext.Remove(route);
        await _routeContext.SaveChangesAsync();
        return route;
    }
}