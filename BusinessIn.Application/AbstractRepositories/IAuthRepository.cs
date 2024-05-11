using BusinessIn.Domain.DbMapping.Entities;

namespace BusinessIn.Application.AbstractRepositories;

public interface IAuthRepository {
    public Task<EmployeeEntity?> Login(string email, string password);
    public Task<EmployeeEntity?> ActiveAccount(string email, string password, string newPassword);
}