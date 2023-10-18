using Microsoft.EntityFrameworkCore;
using NearBusCleanArch.Domain.Entities;
using NearBusCleanArch.Domain.Interfaces;
using NearBusCleanArch.Infra.Data.Context;

namespace NearBusCleanArch.Infra.Data.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private ApplicationDbContext _employeeContext;
    public EmployeeRepository(ApplicationDbContext context)
    {
        _employeeContext = context;
    }
    public async Task<Employee> GetEmployeeById(int? id)
    {
        return await _employeeContext.Employees.FindAsync(id);
    }

    public async Task<IEnumerable<Employee>> GetEmployeesByCompanieId(int? id)
    {
        return await _employeeContext.Employees.Where(employee => employee.CompanieId == id).ToListAsync();
    }

    public async Task<Employee> Create(Employee employee)
    {
        _employeeContext.Add(employee);
        await _employeeContext.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee> Update(Employee employee)
    {
        _employeeContext.Update(employee);
        await _employeeContext.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee> Remove(Employee employee)
    {
        _employeeContext.Remove(employee);
        await _employeeContext.SaveChangesAsync();
        return employee;
    }
}