using BusinessIn.Domain.RequestDTOs;
using FluentValidation;

namespace BusinessIn.Application.Common.Validators;

public class TeamDtoValidator : AbstractValidator<TeamDto> {
    public TeamDtoValidator() {
        RuleFor(x => x.Name.Trim()).Length(2, 50);
    }
}