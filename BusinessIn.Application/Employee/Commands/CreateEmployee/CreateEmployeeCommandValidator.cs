using System.Text.RegularExpressions;
using FluentValidation;

namespace BusinessIn.Application.Employee.Commands.CreateEmployee;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand> {
    public CreateEmployeeCommandValidator() {
        RuleFor(x => x.Employee.FirstName.Trim())
            .NotEmpty().MinimumLength(3).MaximumLength(100);
        
        RuleFor(x => x.Employee.LastName.Trim())
            .NotEmpty().MinimumLength(3).MaximumLength(100);

        RuleFor(x => x.Employee.Email).NotEmpty().Matches(new Regex(""));
    }
    
    // public async Task<IErrorOr<EmployeeEntity>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken,
    //     RequestHandlerDelegate<IErrorOr<EmployeeEntity>> next) {
    //     var result = await next();
    //     return result;
    // }
}