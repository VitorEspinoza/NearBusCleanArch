using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NearBusCleanArch.Domain.Entities;

namespace NearBusCleanArch.Infra.Data.EntitiesConfiguration;

public class AdressConfiguration : IEntityTypeConfiguration<Adress>
{
    public void Configure(EntityTypeBuilder<Adress> builder)
    {
        builder.HasKey(adress => adress.Id);
        builder.Property(adress => adress.Street).HasMaxLength(100).IsRequired();
        builder.Property(adress => adress.Neighborhood).HasMaxLength(40).IsRequired();
        builder.Property(adress => adress.City).HasMaxLength(40).IsRequired();
        builder.Property(adress => adress.State).HasMaxLength(30).IsRequired();
        builder.Property(adress => adress.Number).HasMaxLength(5).IsRequired();
        builder.Property(adress => adress.ZipCode).HasMaxLength(8).IsRequired();

        builder.HasOne(adress => adress.Companie).WithOne(companie => companie.Adress)
            .HasForeignKey<Companie>(companie => companie.AdressId);
    }
}