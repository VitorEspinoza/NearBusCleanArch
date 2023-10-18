using Microsoft.EntityFrameworkCore;
using NearBusCleanArch.Domain.Entities;

namespace NearBusCleanArch.Infra.Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
    }

    public DbSet<Adress> Adresses { get; set; }
    public DbSet<Companie> Companies { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Route> Routes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}