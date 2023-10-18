using NearBusCleanArch.Domain.Entities;

namespace NearBusCleanArch.Domain.Interfaces;

public interface IAdressRepository
{
    Task<Adress> GetAdressById(int? id);
    Task<Adress> Create(Adress adress);
    Task<Adress> Update(Adress adress);
    Task<Adress> Remove(Adress adress);
}