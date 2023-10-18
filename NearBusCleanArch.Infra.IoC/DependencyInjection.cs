using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NearBusCleanArch.Application.Interfaces;
using NearBusCleanArch.Application.Mappings;
using NearBusCleanArch.Application.Services;
using NearBusCleanArch.Domain.Interfaces;
using NearBusCleanArch.Infra.Data.Context;
using NearBusCleanArch.Infra.Data.Repositories;

namespace NearBusCleanArch.Infra.Ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var mySqlConnection = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(
            mySqlConnection,
            ServerVersion.AutoDetect(mySqlConnection),
            builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IAdressRepository, AdressRepository>();
        services.AddScoped<ICompanieRepository, CompanieRepository>();
        services.AddScoped<IRouteRepository, RouteRepository>();

        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IAdressService, AdressService>();
        services.AddScoped<ICompanieService, CompanieService>();
        services.AddScoped<IRouteService, RouteService>();
        
        services.AddAutoMapper(typeof(DomainToDtoMappingProfile));
        return services;
    }
}