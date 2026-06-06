using FluentValidation;

namespace Application.MediatR.RoomAmenities.Commands.Update;

public class UpdateRoomAmenityCommandValidator : AbstractValidator<UpdateRoomAmenityCommand> {
	public UpdateRoomAmenityCommandValidator() {
		RuleFor(ra => ra.Name)
			.NotEmpty()
				.WithMessage("Name is empty or null.")
			.MaximumLength(255)
				.WithMessage("Name is too long.");
	}
}
