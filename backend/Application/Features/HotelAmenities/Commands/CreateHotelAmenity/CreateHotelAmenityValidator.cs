using FluentValidation;

namespace Application.Features.HotelAmenities.Commands.CreateHotelAmenity;

public class CreateHotelAmenityValidator : AbstractValidator<CreateHotelAmenityCommand>
{
    public CreateHotelAmenityValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Image).NotEmpty().MaximumLength(500);
    }
}
