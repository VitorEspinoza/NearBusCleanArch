using AutoMapper;
using NearBusCleanArch.Application.DTOs;
using NearBusCleanArch.Application.Interfaces;
using NearBusCleanArch.Domain.Entities;
using NearBusCleanArch.Domain.Interfaces;

namespace NearBusCleanArch.Application.Services;

public class AdressService : IAdressService
{
    private IAdressRepository _adressRepository;
    private readonly IMapper _mapper;

    public AdressService(IAdressRepository adressRepository, IMapper mapper)
    {
        _adressRepository = adressRepository;
        _mapper = mapper;
    }

    public async Task<AdressDTO> GetAdressById(int? id)
    {
        var adressEntity = await _adressRepository.GetAdressById(id);
        return _mapper.Map<AdressDTO>(adressEntity);
    }

    public async Task Add(AdressDTO adressDto)
    {
        var adressEntity = _mapper.Map<Adress>(adressDto);
        await _adressRepository.Create(adressEntity);
    }

    public async Task Update(AdressDTO adressDto)
    {
        var adressEntity = _mapper.Map<Adress>(adressDto);
        await _adressRepository.Update(adressEntity);
    }

    public async Task Remove(int? id)
    {
        var adressEntity = _adressRepository.GetAdressById(id).Result;
        await _adressRepository.Remove(adressEntity);
    }
}