using NearBusCleanArch.Application.DTOs;
using NearBusCleanArch.Domain.Entities;

namespace NearBusCleanArch.Application.Interfaces;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDTO>> GetEmployeesByCompanieId(int? id);
    Task<EmployeeDTO> GetEmployeeById(int? id);
    Task Add(EmployeeDTO employeeDto);
    Task Update(EmployeeDTO employeeDto);
    Task Remove(int? id);

}