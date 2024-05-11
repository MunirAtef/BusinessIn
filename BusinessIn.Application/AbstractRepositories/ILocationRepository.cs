using BusinessIn.Domain.DbMapping.Entities;

namespace BusinessIn.Application.AbstractRepositories;

public interface ILocationRepository {
    public Task<List<LocationEntity>> GetAll();
    public Task<Guid?> Create(LocationEntity locationEntity);
    public Task<bool> Update(Guid id, LocationEntity locationEntity);
    public Task<bool> DeleteById(Guid guid);
}