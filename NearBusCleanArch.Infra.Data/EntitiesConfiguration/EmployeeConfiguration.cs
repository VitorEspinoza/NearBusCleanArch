using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NearBusCleanArch.Domain.Entities;

namespace NearBusCleanArch.Infra.Data.EntitiesConfiguration;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(employee => employee.Id);
        builder.Property(employee => employee.Name).HasMaxLength(100).IsRequired();
        builder.Property(employee => employee.Document).HasMaxLength(11).IsRequired();

        builder.HasOne(employee => employee.Companie)
            .WithMany(companie => companie.Employees)
            .HasForeignKey(employee => employee.CompanieId);

        builder.HasOne(employee => employee.Adress)
            .WithMany(adress => adress.Employees)
            .HasForeignKey(employee => employee.AdressId);
    }
}