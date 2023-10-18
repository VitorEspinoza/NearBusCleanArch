using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NearBusCleanArch.Domain.Entities;

namespace NearBusCleanArch.Infra.Data.EntitiesConfiguration;

public class CompanieConfiguration : IEntityTypeConfiguration<Companie>
{
    public void Configure(EntityTypeBuilder<Companie> builder)
    {
        builder.HasKey(companie => companie.Id);
        builder.Property(companie => companie.Name).HasMaxLength(100).IsRequired();
        builder.Property(companie => companie.Document).HasMaxLength(14).IsRequired();

        
    }
}