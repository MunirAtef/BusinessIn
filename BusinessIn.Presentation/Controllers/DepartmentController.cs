using BusinessIn.Application.AbstractRepositories;
using BusinessIn.Domain.Constants;
using BusinessIn.Domain.DbMapping.Entities;
using BusinessIn.Domain.RequestDTOs;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusinessIn.Presentation.Controllers;

[AllowAnonymous]
public class DepartmentsController(IDepartmentRepository departmentRepository) : SuperController {
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] Guid locationId) {
        // var locId = GetQueryParameter("locationId");
        // if (locId == null) return BadRequest("Provide locationId");
        
        return Ok(await departmentRepository.GetAll(locationId));
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id) {
        var loc = await departmentRepository.GetById(id);
        return loc != null? Ok(loc) : NotFound();
    }
    
    [HttpPost]
    [Authorize(Policy = Policies.HrManager)]
    public async Task<IActionResult> Create(DepartmentDto department) {
        var departmentEntity = department.Adapt<DepartmentEntity>();
        departmentEntity.Id = Guid.NewGuid();
        var id = await departmentRepository.Create(departmentEntity);
        return id != null? Ok(id) : BadRequest();
    }
    
    
    [HttpPut("{id:guid}")]
    [Authorize(Policy = Policies.HrManager)]
    public async Task<IActionResult> Update(Guid id, [FromBody] string newName) {
        await departmentRepository.UpdateName(id, newName);
        return Ok();
    }
    
    [HttpDelete("{id:guid}")]
    [Authorize(Policy = Policies.HrManager)]
    public async Task<IActionResult> Delete(Guid id) {
        await departmentRepository.DeleteById(id);
        return NoContent();
    }

    [HttpGet("{id:guid}/employees")]
    public async Task<IActionResult> GetEmployees(Guid id) {
        return Ok(await departmentRepository.GetEmployees(id));
    }
}