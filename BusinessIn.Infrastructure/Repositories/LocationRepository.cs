using BusinessIn.Application.AbstractRepositories;
using BusinessIn.Domain.DbMapping.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessIn.Infrastructure.Repositories;

public class LocationRepository(ApplicationDbContext dbContext) : ILocationRepository {
    public async Task<List<LocationEntity>> GetAll() {
        return await dbContext.Locations.ToListAsync();
    }

    public async Task<Guid?> Create(LocationEntity locationEntity) {
        var result = dbContext.Locations.Add(locationEntity);
        await dbContext.SaveChangesAsync();
        Console.WriteLine(dbContext.Locations.ToList());
        return result.Entity.Id;
    }

    public async Task<bool> Update(Guid id, LocationEntity locationEntity) {
        await Task.Delay(0);
        dbContext.Locations.Update(locationEntity);
        return true;
    }

    public async Task<bool> DeleteById(Guid guid) {
        var deleted = await dbContext.Locations.Where(e => e.Id == guid).ExecuteDeleteAsync();
        return deleted == 1;
    }
}