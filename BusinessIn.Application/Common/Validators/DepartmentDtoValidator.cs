using BusinessIn.Domain.RequestDTOs;
using FluentValidation;

namespace BusinessIn.Application.Common.Validators;

public class DepartmentDtoValidator : AbstractValidator<DepartmentDto> {
    public DepartmentDtoValidator() {
        RuleFor(x => x.Name.Trim()).Length(2, 50);
    }
}