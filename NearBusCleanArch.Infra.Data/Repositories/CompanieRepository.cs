using Microsoft.EntityFrameworkCore;
using NearBusCleanArch.Domain.Entities;
using NearBusCleanArch.Domain.Interfaces;
using NearBusCleanArch.Infra.Data.Context;

namespace NearBusCleanArch.Infra.Data.Repositories;

public class CompanieRepository : ICompanieRepository
{
    private ApplicationDbContext _companieContext;
    public CompanieRepository(ApplicationDbContext context)
    {
        _companieContext = context;
    }
    public async Task<IEnumerable<Companie>> GetCompanies()
    {
        return await _companieContext.Companies.ToListAsync();
    }

    public async Task<Companie> GetCompanieById(int? id)
    {
        return await _companieContext.Companies.FindAsync(id);
    }

    public async Task<Companie> Create(Companie companie)
    {
        _companieContext.Add(companie);
        await _companieContext.SaveChangesAsync();
        return companie;
    }

    public async Task<Companie> Update(Companie companie)
    {
        _companieContext.Update(companie);
        await _companieContext.SaveChangesAsync();
        return companie;
    }

    public async Task<Companie> Remove(Companie companie)
    {
        _companieContext.Remove(companie);
        await _companieContext.SaveChangesAsync();
        return companie;
    }
}