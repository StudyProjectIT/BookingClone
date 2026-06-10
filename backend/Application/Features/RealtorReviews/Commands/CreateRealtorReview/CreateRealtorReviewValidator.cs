using FluentValidation;

namespace Application.Features.RealtorReviews.Commands.CreateRealtorReview;

public class CreateRealtorReviewValidator : AbstractValidator<CreateRealtorReviewCommand>
{
    public CreateRealtorReviewValidator()
    {
        RuleFor(x => x.AuthorId).GreaterThan(0);
        RuleFor(x => x.RealtorId).GreaterThan(0);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(2000);
        RuleFor(x => x.Score)
            .InclusiveBetween(1, 10)
            .WithMessage("Score must be between 1 and 10.")
            .When(x => x.Score.HasValue);
    }
}
