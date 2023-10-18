using AutoMapper;
using NearBusCleanArch.Application.DTOs;
using NearBusCleanArch.Application.Interfaces;
using NearBusCleanArch.Domain.Entities;
using NearBusCleanArch.Domain.Interfaces;

namespace NearBusCleanArch.Application.Services;

public class EmployeeService : IEmployeeService
{

    private IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;
    public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<EmployeeDTO>> GetEmployeesByCompanieId(int? id)
    {
        var employeesEntity = await _employeeRepository.GetEmployeesByCompanieId(id);
        return _mapper.Map<IEnumerable<EmployeeDTO>>(employeesEntity);
    }

    public async Task<EmployeeDTO> GetEmployeeById(int? id)
    {
        var employeeEntity = await _employeeRepository.GetEmployeeById(id);
        return _mapper.Map<EmployeeDTO>(employeeEntity);
    }

    public async Task Add(EmployeeDTO employeeDto)
    {
        var employeEntity = _mapper.Map<Employee>(employeeDto);
        await _employeeRepository.Create(employeEntity);
    }

    public async Task Update(EmployeeDTO employeeDto)
    {
        var employeEntity = _mapper.Map<Employee>(employeeDto);
        await _employeeRepository.Update(employeEntity);
    }

    public async Task Remove(int? id)
    {
        var employeeEntity = _employeeRepository.GetEmployeeById(id).Result;
        await _employeeRepository.Remove(employeeEntity);
    }
}