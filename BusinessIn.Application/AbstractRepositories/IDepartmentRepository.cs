using BusinessIn.Domain.DbMapping.Entities;

namespace BusinessIn.Application.AbstractRepositories;


public interface IDepartmentRepository {
    Task<Guid?> Create(DepartmentEntity departmentEntity);
    Task<DepartmentEntity?> GetById(Guid guid);
    Task<List<DepartmentEntity>> GetAll(Guid locationGuid);
    Task<bool> UpdateName(Guid guid, string newDepartmentName);
    Task<bool> DeleteById(Guid guid);
    Task<List<EmployeeEntity>> GetEmployees(Guid id);
}