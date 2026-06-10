using FluentValidation;

namespace Application.Features.Addresses.Commands.UpdateAddress;

public class UpdateAddressValidator : AbstractValidator<UpdateAddressCommand>
{
    public UpdateAddressValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Street).NotEmpty().MaximumLength(255);
        RuleFor(x => x.HouseNumber).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Floor).GreaterThanOrEqualTo(0).When(x => x.Floor.HasValue);
        RuleFor(x => x.ApartmentNumber).MaximumLength(20).When(x => x.ApartmentNumber != null);
        RuleFor(x => x.CityId).GreaterThan(0);
    }
}
