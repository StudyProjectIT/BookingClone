using FluentValidation;

namespace Application.Features.RoomAmenities.Commands.CreateRoomAmenity;

public class CreateRoomAmenityValidator : AbstractValidator<CreateRoomAmenityCommand>
{
    public CreateRoomAmenityValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}
