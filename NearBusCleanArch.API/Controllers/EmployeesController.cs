using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NearBusCleanArch.Application.DTOs;
using NearBusCleanArch.Application.Interfaces;

namespace NearBusCleanArch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetByCompanieId(int id)
        {
            var employees = await _employeeService.GetEmployeesByCompanieId(id);

            if (employees == null)
                return NotFound("Employees not found");
            
            return Ok(employees);
        }
        
        [HttpGet("{id:int}", Name = "GetEmployee")]
        public async Task<ActionResult<EmployeeDTO>> GetById(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);

            if (employee == null)
                return NotFound("Employee not found");
            
            return Ok(employee);
        }
        
        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> Post([FromBody] EmployeeDTO employeeDto)
        {
            if (employeeDto == null)
                return BadRequest("Invalid Data");
            
            await _employeeService.Add(employeeDto);
            
            return new CreatedAtRouteResult("GetEmployee", new{ id = employeeDto.Id }, employeeDto );
        }
        
        [HttpPut]
        public async Task<ActionResult<EmployeeDTO>> Put(int id, [FromBody] EmployeeDTO employeeDto)
        {
            if (id != employeeDto.Id)
                return BadRequest("Invalid Data");
            
            if (employeeDto == null)
                return BadRequest("Invalid Data");
            
            await _employeeService.Update(employeeDto);
            
            return Ok(employeeDto);
        }
        
        [HttpDelete]
        public async Task<ActionResult<EmployeeDTO>> Delete(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            if (employee == null)
                return NotFound("Employee not found");
            
            await _employeeService.Remove(id);

            return Ok(employee);
        }
    }
}
