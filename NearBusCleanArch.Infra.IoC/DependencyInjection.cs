using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NearBusCleanArch.Domain.Interfaces;
using NearBusCleanArch.Infra.Data.Context;
using NearBusCleanArch.Infra.Data.Repositories;

namespace NearBusCleanArch.Infra.Ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(
            ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection")),
            builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IAdressRepository, AdressRepository>();
        services.AddScoped<ICompanieRepository, CompanieRepository>();
        services.AddScoped<IRouteRepository, RouteRepository>();

        return services;
    }
}