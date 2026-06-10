using FluentValidation;

namespace Application.Features.RoomAmenities.Commands.UpdateRoomAmenity;

public class UpdateRoomAmenityValidator : AbstractValidator<UpdateRoomAmenityCommand>
{
    public UpdateRoomAmenityValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}
