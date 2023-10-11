using NearBusCleanArch.Domain.Entities;
using NearBusCleanArch.Domain.Interfaces;
using NearBusCleanArch.Infra.Data.Context;

namespace NearBusCleanArch.Infra.Data.Repositories;

public class AdressRepository : IAdressRepository
{
    private ApplicationDbContext _adressContext;
    
    public AdressRepository(ApplicationDbContext context)
    {
        _adressContext = context;
    }
    public async Task<Adress> GetAdressById(int? id)
    {
        return await _adressContext.Adresses.FindAsync(id);
    }

    public async Task<Adress> Create(Adress adress)
    {
        _adressContext.Add(adress);
        await _adressContext.SaveChangesAsync();
        return adress;
    }

    public async Task<Adress> Update(Adress adress)
    {
        _adressContext.Update(adress);
        await _adressContext.SaveChangesAsync();
        return adress;
    }

    public async Task<Adress> Remove(Adress adress)
    {
        _adressContext.Remove(adress);
        await _adressContext.SaveChangesAsync();
        return adress;
    }
}