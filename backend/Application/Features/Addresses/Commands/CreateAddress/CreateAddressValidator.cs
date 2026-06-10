using FluentValidation;

namespace Application.Features.Addresses.Commands.CreateAddress;

public class CreateAddressValidator : AbstractValidator<CreateAddressCommand>
{
    public CreateAddressValidator()
    {
        RuleFor(x => x.Street).NotEmpty().MaximumLength(255);
        RuleFor(x => x.HouseNumber).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Floor).GreaterThanOrEqualTo(0).When(x => x.Floor.HasValue);
        RuleFor(x => x.ApartmentNumber).MaximumLength(20).When(x => x.ApartmentNumber != null);
        RuleFor(x => x.CityId).GreaterThan(0);
    }
}
