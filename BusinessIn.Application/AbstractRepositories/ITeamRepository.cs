using BusinessIn.Domain.DbMapping.Entities;

namespace BusinessIn.Application.AbstractRepositories;

public interface ITeamRepository {
    public Task<Guid?> Create(TeamEntity teamEntity);
    public Task<TeamEntity?> GetById(Guid id);
    public Task<List<TeamEntity>> GetAllTeams();
    public Task<List<EmployeeEntity>> GetEmployees(Guid teamId);
    public Task<EmployeeEntity?> GetLeader(Guid teamId);
    public Task ChangeLeader(Guid teamId, Guid leaderId);
    public Task Update(TeamEntity teamEntity);
    public Task DeleteById(Guid id);
}