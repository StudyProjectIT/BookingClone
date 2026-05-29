using FluentValidation;

namespace Application.Features.Bookings.Commands.UpdateBooking;

public class UpdateBookingValidator : AbstractValidator<UpdateBookingCommand>
{
    public UpdateBookingValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.RoomVariantId).GreaterThan(0);
        RuleFor(x => x.Quantity).InclusiveBetween(1, 100);
        RuleFor(x => x.CheckIn).NotEmpty();
        RuleFor(x => x.CheckOut).GreaterThan(x => x.CheckIn)
            .WithMessage("CheckOut must be later than CheckIn.");
        RuleFor(x => x.TotalPrice).GreaterThanOrEqualTo(0);
    }
}
