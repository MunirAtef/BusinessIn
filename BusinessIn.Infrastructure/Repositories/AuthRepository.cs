using BusinessIn.Application.AbstractRepositories;
using BusinessIn.Domain.DbMapping.Entities;
using BusinessIn.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace BusinessIn.Infrastructure.Repositories;

public class AuthRepository(IEmployeesRepository employeesRepository, ApplicationDbContext dbContext)
    : IAuthRepository {
    public async Task<EmployeeEntity?> Login(string email, string password) {
        var employee = await employeesRepository.GetByEmail(email);
        if (employee == null) return null;
        if (employee.Status != AccountStatus.Activated) return null;
        var checkPass = CheckIfPassValid(password, employee.HashedPassword);
        return checkPass ? employee : null;
    }

    public async Task<EmployeeEntity?> ActiveAccount(string email, string password, string newPassword) {
        var employee = await employeesRepository.GetByEmail(email);
        if (employee == null) return null;
        if (employee.Status != AccountStatus.Created) return null;
        var checkPass = CheckIfPassValid(password, employee.HashedPassword);
        if (!checkPass) return null;

        await dbContext.Employees.Where(e => e.Email == email)
            .ExecuteUpdateAsync(calls =>
                calls.SetProperty(e => password, HashPassword(newPassword))
                    .SetProperty(e => e.Status, AccountStatus.Activated));

        return employee;
    }

    private static bool CheckIfPassValid(string password, string hashedPassword) {
        return password == hashedPassword;
    }

    private static string HashPassword(string password) {
        return $"HASH::{password}";
    }
}