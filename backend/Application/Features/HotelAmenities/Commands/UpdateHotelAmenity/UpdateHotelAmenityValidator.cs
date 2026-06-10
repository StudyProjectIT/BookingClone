using FluentValidation;

namespace Application.Features.HotelAmenities.Commands.UpdateHotelAmenity;

public class UpdateHotelAmenityValidator : AbstractValidator<UpdateHotelAmenityCommand>
{
    public UpdateHotelAmenityValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Image).NotEmpty().MaximumLength(500);
    }
}
