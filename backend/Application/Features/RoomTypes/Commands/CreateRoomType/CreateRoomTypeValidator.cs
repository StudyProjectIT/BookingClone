using FluentValidation;

namespace Application.Features.RoomTypes.Commands.CreateRoomType;

public class CreateRoomTypeValidator : AbstractValidator<CreateRoomTypeCommand>
{
    public CreateRoomTypeValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}
