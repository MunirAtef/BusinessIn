using BusinessIn.Domain.DbMapping.Entities;

namespace BusinessIn.Application.AbstractRepositories;

public interface IEmployeesRepository {
    public Task<EmployeeEntity?> GetById(Guid guid);
    public Task<EmployeeEntity?> GetByEmail(string email);
    public Task<List<EmployeeEntity>> GetAll();
    public Task<Guid?> Create(EmployeeEntity employeeEntity);
    public Task Update(EmployeeEntity employeeEntity);
    public Task DeleteById(Guid guid);
    public Task<EmployeeEntity?> GetSupervisor(Guid id);
    Task<List<EmployeeEntity>> GetSuperviseOn(Guid id);
}