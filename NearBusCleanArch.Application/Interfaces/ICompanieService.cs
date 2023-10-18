using NearBusCleanArch.Application.DTOs;

namespace NearBusCleanArch.Application.Interfaces;

public interface ICompanieService 
{
    Task<IEnumerable<CompanieDTO>> GetCompanies();
    Task<CompanieDTO> GetCompanieById(int? id);
    Task Add(CompanieDTO companieDto);
    Task Update(CompanieDTO companieDto);
    Task Remove(int? id);
}