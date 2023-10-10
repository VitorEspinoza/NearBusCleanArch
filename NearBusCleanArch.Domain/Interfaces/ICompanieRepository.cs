using NearBusCleanArch.Domain.Entities;

namespace NearBusCleanArch.Domain.Interfaces;

public interface ICompanieRepository
{
    Task<IEnumerable<Companie>> GetCompanies();
    Task<Companie> GetCompanieById(int? id);
    Task<Companie> Create(Companie companie);
    Task<Companie> Update(Companie companie);
    Task<Companie> Remove(Companie companie);
}