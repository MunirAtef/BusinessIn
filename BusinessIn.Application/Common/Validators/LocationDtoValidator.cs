using BusinessIn.Domain.RequestDTOs;
using FluentValidation;

namespace BusinessIn.Application.Common.Validators;

public class LocationDtoValidator : AbstractValidator<LocationDto> {
    public LocationDtoValidator() {
        RuleFor(x => x.City.Trim()).Length(3, 50);
        RuleFor(x => x.Country.Trim()).Length(3, 50);
        RuleFor(x => x.PostalCode.Trim()).Length(3, 20);
        RuleFor(x => x.Region.Trim()).Length(3, 50);
        RuleFor(x => x.StreetAddress).Null().MinimumLength(100);
    }
}