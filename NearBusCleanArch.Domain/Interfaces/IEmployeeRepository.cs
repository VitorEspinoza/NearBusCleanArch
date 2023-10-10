using NearBusCleanArch.Domain.Entities;

namespace NearBusCleanArch.Domain.Interfaces;

public interface IEmployeeRepository
{
    Task<Employee> GetEmployeeById(int? id);
    Task<IEnumerable<Employee>> GetEmployeesByCompanieId(int? id);
    Task<Employee> Create(Employee employee);
    Task<Employee> Update(Employee employee);
    Task<Employee> Remove(Employee employee);
}