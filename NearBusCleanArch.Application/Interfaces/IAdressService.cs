using NearBusCleanArch.Application.DTOs;

namespace NearBusCleanArch.Application.Interfaces;

public interface IAdressService
{
    Task<AdressDTO> GetAdressById(int? id);
    Task Add(AdressDTO adressDto);
    Task Update(AdressDTO adressDto);
    Task Remove(int? id);
}