using BusinessIn.Domain.RequestDTOs;
using FluentValidation;

namespace BusinessIn.Application.Common.Validators;

public class ActiveAccountDtoValidator : AbstractValidator<ActiveAccountDto> {
    public ActiveAccountDtoValidator() {
        RuleFor(dto => dto.Email).EmailAddress();
        RuleFor(dto => dto.Password).Length(8, 100);
        RuleFor(dto => dto.NewPassword).Length(8, 100);
    }
}