using BusinessIn.Application.AbstractRepositories;
using BusinessIn.Domain.DbMapping.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessIn.Infrastructure.Repositories;

public class DepartmentRepository(ApplicationDbContext dbContext) : IDepartmentRepository {
    public async Task<Guid?> Create(DepartmentEntity departmentEntity) {
        var result = dbContext.Departments.Add(departmentEntity);
        await dbContext.SaveChangesAsync();
        return result.Entity.Id;
    }

    public async Task<DepartmentEntity?> GetById(Guid guid) {
        return await dbContext.Departments.FirstOrDefaultAsync(e => e.Id == guid);
    }

    public async Task<List<DepartmentEntity>> GetAll(Guid locationGuid) {
        return await dbContext.Departments.ToListAsync();
    }

    public async Task<bool> UpdateName(Guid id, string newName) {
        await dbContext.Departments.Where(e => e.Id == id)
            .ExecuteUpdateAsync(e =>
                e.SetProperty(department => department.Name, newName));
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteById(Guid guid) {
        var result = await dbContext.Departments.Where(e => e.Id == guid).ExecuteDeleteAsync();
        return result == 1;
    }

    public async Task<List<EmployeeEntity>> GetEmployees(Guid guid) {
        return await dbContext.Employees.Where(e => e.DepartmentId == guid).ToListAsync();
    }
}