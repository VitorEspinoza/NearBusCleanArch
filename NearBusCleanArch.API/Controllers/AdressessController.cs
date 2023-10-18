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
    public class AdressessController : ControllerBase
    {
        private readonly IAdressService _adressService;

        public AdressessController(IAdressService adressService)
        {
            _adressService = adressService;
        }
        
        [HttpGet("{id:int}", Name = "GetAdress")]
        public async Task<ActionResult<AdressDTO>> GetById(int id)
        {
            var adress = await _adressService.GetAdressById(id);

            if (adress == null)
                return NotFound("Adress not found");
            
            return Ok(adress);
        }
        
        [HttpPost]
        public async Task<ActionResult<AdressDTO>> Post([FromBody] AdressDTO adressDto)
        {
            if (adressDto == null)
                return BadRequest("Invalid Data");
            
            await _adressService.Add(adressDto);
            
            return new CreatedAtRouteResult("GetAdress", new{ id = adressDto.Id }, adressDto );
        }
        
        [HttpPut]
        public async Task<ActionResult<AdressDTO>> Put(int id, [FromBody] AdressDTO adressDto)
        {
            if (id != adressDto.Id)
                return BadRequest("Invalid Data");
            
            if (adressDto == null)
                return BadRequest("Invalid Data");
            
            await _adressService.Update(adressDto);
            
            return Ok(adressDto);
        }
        
        [HttpDelete]
        public async Task<ActionResult<AdressDTO>> Delete(int id)
        {
            var adress = await _adressService.GetAdressById(id);
            if (adress == null)
                return NotFound("Adress not found");
            
            await _adressService.Remove(id);

            return Ok(adress);
        }
    }
}
