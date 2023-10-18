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
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanieService _companieService;

        public CompaniesController(ICompanieService companieService)
        {
            _companieService = companieService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanieDTO>>> Get()
        {
            var companies = await _companieService.GetCompanies();

            if (companies == null)
                return NotFound("Companies not found");
            
            return Ok(companies);
        }
        
        [HttpGet("{id:int}", Name = "GetCompanie")]
        public async Task<ActionResult<CompanieDTO>> GetById(int id)
        {
            var companie = await _companieService.GetCompanieById(id);

            if (companie == null)
                return NotFound("Companie not found");
            
            return Ok(companie);
        }
        
        [HttpPost]
        public async Task<ActionResult<CompanieDTO>> Post([FromBody] CompanieDTO companieDto)
        {
            if (companieDto == null)
                return BadRequest("Invalid Data");
            
            await _companieService.Add(companieDto);
            
            return new CreatedAtRouteResult("GetCompanie", new{ id = companieDto.Id }, companieDto );
        }
        
        [HttpPut]
        public async Task<ActionResult<CompanieDTO>> Put(int id, [FromBody] CompanieDTO companieDto)
        {
            if (id != companieDto.Id)
                return BadRequest("Invalid Data");
            
            if (companieDto == null)
                return BadRequest("Invalid Data");
            
            await _companieService.Update(companieDto);
            
            return Ok(companieDto);
        }
        
        [HttpDelete]
        public async Task<ActionResult<CompanieDTO>> Delete(int id)
        {
            var companie = await _companieService.GetCompanieById(id);
            if (companie == null)
                return NotFound("Companie not found");
            
            await _companieService.Remove(id);

            return Ok(companie);
        }
    }
}
