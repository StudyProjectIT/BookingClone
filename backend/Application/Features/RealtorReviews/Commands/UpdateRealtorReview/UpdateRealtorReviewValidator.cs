using FluentValidation;

namespace Application.Features.RealtorReviews.Commands.UpdateRealtorReview;

public class UpdateRealtorReviewValidator : AbstractValidator<UpdateRealtorReviewCommand>
{
    public UpdateRealtorReviewValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(2000);
        RuleFor(x => x.Score)
            .InclusiveBetween(1, 10)
            .WithMessage("Score must be between 1 and 10.")
            .When(x => x.Score.HasValue);
    }
}
