using BusinessIn.Application.AbstractRepositories;
using BusinessIn.Domain.DbMapping.Entities;
using BusinessIn.Domain.DbMapping.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace BusinessIn.Infrastructure.Repositories;

public class TeamRepository(ApplicationDbContext dbContext) : ITeamRepository {
    public async Task<Guid?> Create(TeamEntity teamEntity) {
        dbContext.Add(teamEntity);
        await dbContext.SaveChangesAsync();
        return teamEntity.Id;
    }

    public async Task<TeamEntity?> GetById(Guid id) {
        return await dbContext.Teams.FirstOrDefaultAsync(team => team.Id == id);
    }

    public async Task<List<TeamEntity>> GetAllTeams() { return await dbContext.Teams.ToListAsync(); }

    public async Task<List<TeamEntity>> GetInDepartment(Guid departmentId) {
        return await dbContext.Teams.Where(team => team.DepartmentId == departmentId).ToListAsync();
    }

    public async Task<List<TeamEntity>> GetInCompany() { return await dbContext.Teams.ToListAsync(); }

    public async Task<List<EmployeeEntity>> GetEmployees(Guid teamId) {
        return await dbContext.Employees.Where(e => e.TeamId == teamId).ToListAsync();
    }

    public async Task<EmployeeEntity?> GetLeader(Guid teamId) {
        var currentDate = DateOnly.FromDateTime(DateTime.UtcNow);

        // var employeeEntities = dbContext.TeamLeaders.Join(
        //     dbContext.Employees,
        //     teamLead => teamLead.TeamId,
        //     emp => emp.Id,
        //     (teamLead, emp) => emp);

        var teamLeader = await dbContext.TeamLeaders.FirstOrDefaultAsync(
            leader => leader.TeamId == teamId && leader.StartDate < currentDate &&
                      (leader.EndDate == null || leader.EndDate > currentDate));

        if (teamLeader == null) return null;
        return await dbContext.Employees.FirstOrDefaultAsync(e => e.Id == teamLeader.LeaderId);
    }

    public async Task ChangeLeader(Guid teamId, Guid leaderId) {
        var currentDate = DateOnly.FromDateTime(DateTime.UtcNow);

        await using var transaction = await dbContext.Database.BeginTransactionAsync();

        await dbContext.TeamLeaders
            .Where(teamLeader => teamLeader.TeamId == teamId && teamLeader.EndDate == null)
            .ExecuteUpdateAsync(calls =>
                calls.SetProperty(teamLeader => teamLeader.EndDate, currentDate));

        await dbContext.TeamLeaders.AddAsync(new TeamLeader {
            TeamId = teamId, LeaderId = leaderId, StartDate = currentDate, EndDate = null
        });

        await dbContext.SaveChangesAsync();
        await transaction.CommitAsync();
    }

    public async Task Update(TeamEntity teamEntity) {
        await Task.Delay(0);
        dbContext.Teams.Update(teamEntity);
    }

    public async Task DeleteById(Guid id) { await dbContext.Teams.Where(team => team.Id == id).ExecuteDeleteAsync(); }
}