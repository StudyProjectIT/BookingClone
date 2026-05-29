using FluentValidation;

namespace Application.Features.Hotels.Commands.CreateHotel;

public class CreateHotelValidator : AbstractValidator<CreateHotelCommand>
{
    public CreateHotelValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(255);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(4000);
        RuleFor(x => x.AddressId).GreaterThan(0);
        RuleFor(x => x.HotelCategoryId).GreaterThan(0);
        RuleFor(x => x.RealtorId).GreaterThan(0);
        RuleFor(x => x.ArrivalTimeUtcTo).GreaterThan(x => x.ArrivalTimeUtcFrom);
        RuleFor(x => x.DepartureTimeUtcTo).GreaterThan(x => x.DepartureTimeUtcFrom);
    }
}
