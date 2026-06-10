using FluentValidation;

namespace Application.Features.HotelReviews.Commands.CreateHotelReview;

public class CreateHotelReviewValidator : AbstractValidator<CreateHotelReviewCommand>
{
    public CreateHotelReviewValidator()
    {
        RuleFor(x => x.BookingId).GreaterThan(0);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(2000);
        RuleFor(x => x.Score)
            .InclusiveBetween(1, 10)
            .WithMessage("Score must be between 1 and 10.")
            .When(x => x.Score.HasValue);
    }
}
