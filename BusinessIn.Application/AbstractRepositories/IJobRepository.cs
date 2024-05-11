using BusinessIn.Domain.DbMapping.Entities;

namespace BusinessIn.Application.AbstractRepositories;

public interface IJobRepository {
    public Task<List<JobEntity>> GetAll();
    public Task<JobEntity?> GetById(Guid guid);
    public Task<JobEntity?> Create(JobEntity jobEntity);
    public Task<JobEntity?> Update(JobEntity jobEntity);
    public Task<JobEntity?> DeleteById(Guid guid);
}