using BusinessIn.Application.AbstractRepositories;
using BusinessIn.Domain.DbMapping.Entities;
using BusinessIn.Domain.RequestDTOs;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace BusinessIn.Presentation.Controllers;

public class LocationsController(ILocationRepository locationRepository) : SuperController {
    
    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var userId = GetUserId();
        Console.WriteLine($"From Req: {userId}");
        return Ok(await locationRepository.GetAll());
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(LocationDto location) {
        var locationEntity = location.Adapt<LocationEntity>();
        locationEntity.Id = Guid.NewGuid();
        return Ok(await locationRepository.Create(locationEntity));
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, LocationDto location) {
        var locationEntity = location.Adapt<LocationEntity>();
        locationEntity.Id = id;
        await locationRepository.Update(id, locationEntity);
        return Ok();
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteById(Guid id) {
        var deleted = await locationRepository.DeleteById(id);
        if (deleted) return NoContent();
        return NotFound();
    }
}

/*
{
  "postalCode": "CRO-5345",
  "region": "North Africa",
  "country": "Egypt",
  "city": "Cairo",
  "streetAddress": "Monib"
}
*/