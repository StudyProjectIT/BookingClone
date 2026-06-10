using FluentValidation;

namespace Application.Features.Breakfasts.Commands;

public class UpdateBreakfastValidator : AbstractValidator<UpdateBreakfastCommand>
{
    public UpdateBreakfastValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}
