using BusinessIn.Application.AbstractRepositories;
using BusinessIn.Domain.DbMapping.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessIn.Infrastructure.Repositories;

public class EmployeeRepository(ApplicationDbContext dbContext) : IEmployeesRepository {
    public async Task<Guid?> Create(EmployeeEntity employeeEntity) {
        dbContext.Employees.Add(employeeEntity);
        await dbContext.SaveChangesAsync();
        return employeeEntity.Id;
    }

    public async Task<EmployeeEntity?> GetById(Guid guid) {
        await Task.Delay(0);
        var employee = dbContext.Employees.FirstOrDefault(e => e.Id == guid);
        return employee;
    }

    public async Task<List<EmployeeEntity>> GetAll() => await dbContext.Employees.ToListAsync();

    public async Task<EmployeeEntity?> GetByEmail(string email) {
        await Task.Delay(0);
        var employee = dbContext.Employees.FirstOrDefault(e => e.Email == email);
        return employee;
    }

    public async Task Update(EmployeeEntity employeeEntity) {
        await Task.Delay(0);
        dbContext.Employees.Update(employeeEntity);
    }

    public async Task DeleteById(Guid guid) => 
        await dbContext.Employees.Where(e => e.Id == guid).ExecuteDeleteAsync();

    public async Task<EmployeeEntity?> GetSupervisor(Guid id) {
        await Task.Delay(0);

        return dbContext.Employees
            .Include(employee => employee.Supervisor)
            .FirstOrDefault(e => e.Id == id)?.Supervisor;

        // var superId = dbContext.Employees.FirstOrDefault(e => e.Id == id)?.SupervisorId;
        // return superId == null ? null : dbContext.Employees.FirstOrDefault(e => e.Id == superId);
    }

    public async Task<List<EmployeeEntity>> GetSuperviseOn(Guid id) =>
        await dbContext.Employees.Where(e => e.SupervisorId == id).ToListAsync();
}