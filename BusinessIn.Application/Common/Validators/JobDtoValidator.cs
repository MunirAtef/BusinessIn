using BusinessIn.Domain.RequestDTOs;
using FluentValidation;

namespace BusinessIn.Application.Common.Validators;

public class JobDtoValidator : AbstractValidator<JobDto> {
    public JobDtoValidator() {
        RuleFor(x => x.Title.Trim()).Length(2, 50);
        RuleFor(x => x.JobDescription.Trim()).Length(2, 200);
        RuleFor(x => x.MinSalary).InclusiveBetween(1000, 100000);
        RuleFor(x => x.MaxSalary)
            .InclusiveBetween(1000, 100000).GreaterThan(e => e.MinSalary);
        
    }
}