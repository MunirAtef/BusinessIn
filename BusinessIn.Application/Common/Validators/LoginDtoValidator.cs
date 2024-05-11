using BusinessIn.Domain.RequestDTOs;
using FluentValidation;

namespace BusinessIn.Application.Common.Validators;

public class LoginDtoValidator : AbstractValidator<LoginDto> {
    public LoginDtoValidator() {
        RuleFor(dto => dto.Email).NotEmpty().EmailAddress();
        RuleFor(dto => dto.Password).Length(8, 100);
    }
}