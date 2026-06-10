using FluentValidation;

namespace Application.Features.RoomVariants.Commands.CreateRoomVariant;

public class CreateRoomVariantValidator : AbstractValidator<CreateRoomVariantCommand>
{
    public CreateRoomVariantValidator()
    {
        RuleFor(x => x.RoomId).GreaterThan(0);
        RuleFor(x => x.Price).GreaterThan(0);
        RuleFor(x => x.DiscountPrice)
            .GreaterThan(0)
            .LessThan(x => x.Price)
            .WithMessage("Discount price must be greater than 0 and less than the regular price.")
            .When(x => x.DiscountPrice.HasValue);
        RuleFor(x => x.AdultCount).GreaterThanOrEqualTo(1);
        RuleFor(x => x.ChildCount).GreaterThanOrEqualTo(0);
        RuleFor(x => x.SingleBedCount).GreaterThanOrEqualTo(0);
        RuleFor(x => x.DoubleBedCount).GreaterThanOrEqualTo(0);
        RuleFor(x => x.ExtraBedCount).GreaterThanOrEqualTo(0);
        RuleFor(x => x.SofaCount).GreaterThanOrEqualTo(0);
        RuleFor(x => x.KingsizeBedCount).GreaterThanOrEqualTo(0);
    }
}
