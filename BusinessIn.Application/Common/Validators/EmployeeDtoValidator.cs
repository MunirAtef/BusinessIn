using BusinessIn.Domain.RequestDTOs;
using FluentValidation;

namespace BusinessIn.Application.Common.Validators;

public class EmployeeDtoValidator : AbstractValidator<EmployeeDto> {
    public EmployeeDtoValidator() {
        RuleFor(x => x.FirstName.Trim()).Length(4, 50);
        RuleFor(x => x.LastName.Trim()).Length(4, 50);
        RuleFor(x => x.Email.Trim()).Length(4, 50).EmailAddress();
        RuleFor(x => x.Password).Length(8, 100);
        RuleFor(x => x.Salary).InclusiveBetween(1000, 100000);
        RuleFor(x => x.Salary).InclusiveBetween(1000, 100000);
    }
}