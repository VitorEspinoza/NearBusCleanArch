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
    public class RoutesController : ControllerBase
    {
        private readonly IRouteService _routeService;

        public RoutesController(IRouteService routeService)
        {
            _routeService = routeService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RouteDTO>>> GetRoutesByCompanieId(int id)
        {
            var routes = await _routeService.GetRoutesByCompanieId(id);

            if (routes == null)
                return NotFound("Routes not found");
            
            return Ok(routes);
        }
        
        [HttpGet("{id:int}", Name = "GetRoute")]
        public async Task<ActionResult<RouteDTO>> GetById(int id)
        {
            var route = await _routeService.GetRouteById(id);

            if (route == null)
                return NotFound("Route not found");
            
            return Ok(route);
        }
        
        [HttpPost]
        public async Task<ActionResult<RouteDTO>> Post([FromBody] RouteDTO routeDto)
        {
            if (routeDto == null)
                return BadRequest("Invalid Data");
            
            await _routeService.Add(routeDto);
            
            return new CreatedAtRouteResult("GetRoute", new{ id = routeDto.Id }, routeDto );
        }
        
        [HttpPut]
        public async Task<ActionResult<RouteDTO>> Put(int id, [FromBody] RouteDTO routeDto)
        {
            if (id != routeDto.Id)
                return BadRequest("Invalid Data");
            
            if (routeDto == null)
                return BadRequest("Invalid Data");
            
            await _routeService.Update(routeDto);
            
            return Ok(routeDto);
        }
        
        [HttpDelete]
        public async Task<ActionResult<RouteDTO>> Delete(int id)
        {
            var route = await _routeService.GetRouteById(id);
            if (route == null)
                return NotFound("Route not found");
            
            await _routeService.Remove(id);

            return Ok(route);
        }
    }
}
