using BusinessIn.Application.AbstractRepositories;
using BusinessIn.Domain.DbMapping.Entities;
using BusinessIn.Domain.RequestDTOs;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace BusinessIn.Presentation.Controllers;

public class TeamsController(ITeamRepository teamRepository) : SuperController {
    [HttpPost]
    public async Task<IActionResult> CreateTeam(TeamDto team) {
        var teamEntity = team.Adapt<TeamEntity>();
        teamEntity.Id = Guid.NewGuid();
        var result = await teamRepository.Create(teamEntity);
        return result == null ? BadRequest() : Ok(result);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetTeamById(Guid id) {
        var result = await teamRepository.GetById(id);
        return result == null ? NotFound() : Ok(result);
    }
    
    [HttpGet("{id:guid}/employees")]
    public async Task<IActionResult> GetEmployees(Guid id) {
        var result = await teamRepository.GetEmployees(id);
        return Ok(result);
    }
    
    [HttpGet("{id:guid}/leader")]
    public async Task<IActionResult> GetLeader(Guid id) {
        var result = await teamRepository.GetLeader(id);
        return result == null ? NotFound() : Ok(result);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id) {
        await teamRepository.DeleteById(id);
        return NoContent();
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, TeamDto team) {
        var teamEntity = team.Adapt<TeamEntity>();
        teamEntity.Id = id;
        await teamRepository.Update(teamEntity);
        return Ok();
    }
}