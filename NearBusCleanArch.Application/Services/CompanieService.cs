using AutoMapper;
using NearBusCleanArch.Application.DTOs;
using NearBusCleanArch.Application.Interfaces;
using NearBusCleanArch.Domain.Entities;
using NearBusCleanArch.Domain.Interfaces;

namespace NearBusCleanArch.Application.Services;

public class CompanieService : ICompanieService
{
    private ICompanieRepository _companieRepository;
    private readonly IMapper _mapper;

    public CompanieService(ICompanieRepository companieRepository, IMapper mapper)
    {
        _companieRepository = companieRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CompanieDTO>> GetCompanies()
    {
        var companiesEntity = await _companieRepository.GetCompanies();
        return _mapper.Map<IEnumerable<CompanieDTO>>(companiesEntity);
    }

    public async Task<CompanieDTO> GetCompanieById(int? id)
    {
        var companieEntity = await _companieRepository.GetCompanieById(id);
        return _mapper.Map<CompanieDTO>(companieEntity);
    }

    public async Task Add(CompanieDTO companieDto)
    {
        var companieEntity = _mapper.Map<Companie>(companieDto);
        await _companieRepository.Create(companieEntity);
    }

    public async Task Update(CompanieDTO companieDto)
    {
        var companieEntity = _mapper.Map<Companie>(companieDto);
        await _companieRepository.Update(companieEntity);
    }

    public async Task Remove(int? id)
    {
        var companieEntity = _companieRepository.GetCompanieById(id).Result;
        await _companieRepository.Remove(companieEntity);
    }
}