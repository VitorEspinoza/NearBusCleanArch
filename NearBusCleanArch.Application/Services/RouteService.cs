using AutoMapper;
using NearBusCleanArch.Application.DTOs;
using NearBusCleanArch.Application.Interfaces;
using NearBusCleanArch.Domain.Entities;
using NearBusCleanArch.Domain.Interfaces;

namespace NearBusCleanArch.Application.Services;

public class RouteService : IRouteService
{
    private IRouteRepository _routeRepository;
    private readonly IMapper _mapper;

    public RouteService(IRouteRepository routeRepository, IMapper mapper)
    {
        _routeRepository = routeRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RouteDTO>> GetRoutesByCompanieId(int? id)
    {
        var routesEntity = await _routeRepository.GetRoutesByCompanieId(id);
        return _mapper.Map<IEnumerable<RouteDTO>>(routesEntity);
    }

    public async Task<RouteDTO> GetRouteById(int? id)
    {
        var routeEntity = await _routeRepository.GetRouteById(id);
        return _mapper.Map<RouteDTO>(routeEntity);
    }

    public async Task Add(RouteCreateDTO routeDto)
    {
        var routeEntity = _mapper.Map<Route>(routeDto);
        await _routeRepository.Create(routeEntity);
    }

    public async Task Update(RouteCreateDTO routeDto)
    {
        var routeEntity = _mapper.Map<Route>(routeDto);
        await _routeRepository.Update(routeEntity);
    }

    public async Task Remove(int? id)
    {
        var routeEntity = _routeRepository.GetRouteById(id).Result;
        await _routeRepository.Remove(routeEntity);
    }
}