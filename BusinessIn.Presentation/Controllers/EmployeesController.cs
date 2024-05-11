using BusinessIn.Application.AbstractRepositories;
using BusinessIn.Application.Common.Validators;
using BusinessIn.Domain.Constants;
using BusinessIn.Domain.DbMapping.Entities;
using BusinessIn.Domain.RequestDTOs;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusinessIn.Presentation.Controllers;

[Authorize(Roles = Policies.RegularEmployee)]
public class EmployeesController(IEmployeesRepository employeesRepository) : SuperController {
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id) {
        var employee = await employeesRepository.GetById(id);
        return Ok(employee);
    }

    [HttpGet("{id:guid}/supervisor")]
    public async Task<IActionResult> GetSupervisor(Guid id) {
        var employee = await employeesRepository.GetSupervisor(id);
        return Ok(employee);
    }
    
    [HttpGet("{id:guid}/supervise-on")]
    public async Task<IActionResult> GetSuperviseOn(Guid id) {
        var employee = await employeesRepository.GetSuperviseOn(id);
        return Ok(employee);
    }
    
    [HttpPost]
    [Authorize(Policy = Policies.HrManager)]
    public async Task<IActionResult> CreateEmployee([FromBody] EmployeeDto employeeDto) {
        var validation = await new EmployeeDtoValidator().ValidateAsync(employeeDto);
        if (!validation.IsValid) {
            return BadRequest(validation.Errors);
        }

        var employeeEntity = employeeDto.Adapt<EmployeeEntity>();

        employeeEntity.HashedPassword = "HASH::" + employeeDto.Password;
        employeeEntity.HiringDate = DateOnly.FromDateTime(DateTime.UtcNow);
        employeeEntity.Id = Guid.NewGuid();
        employeeEntity.CreatedAt = DateTime.UtcNow;

        await employeesRepository.Create(employeeEntity);
        return Ok(employeeEntity);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Policy = Policies.HrManager)]
    public async Task<IActionResult> UpdateEmployee(Guid id, EmployeeDto employeeDto) {
        var employeeEntity = employeeDto.Adapt<EmployeeDto, EmployeeEntity>();
        employeeEntity.Id = id;

        await employeesRepository.Update(employeeEntity);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Policy = Policies.HrManager)]
    public async Task<IActionResult> DeleteEmployee(Guid id) {
        await employeesRepository.DeleteById(id);
        return Ok();
    }
}