using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NearBusCleanArch.Domain.Entities;
using NearBusCleanArch.Infra.Data.Converters;

namespace NearBusCleanArch.Infra.Data.EntitiesConfiguration;

public class RouteConfiguration : IEntityTypeConfiguration<Route>
{
    public void Configure(EntityTypeBuilder<Route> builder)
    {
       
        builder.HasKey(route => route.Id);
        builder.Property(route => route.Name).HasMaxLength(200).IsRequired();
        builder.Property(route => route.DepartureTime).IsRequired();
        builder.Property(route => route.DepartureDays).IsRequired().HasConversion(new DayOfWeekArrayConverter());
        
        
        builder
            .HasMany(route => route.Employees)
            .WithMany(employee => employee.Routes);

        builder.HasOne(route => route.Companie)
            .WithMany(companie => companie.Routes);
    }
}