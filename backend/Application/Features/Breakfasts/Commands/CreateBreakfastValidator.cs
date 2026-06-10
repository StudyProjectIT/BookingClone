using FluentValidation;

namespace Application.Features.Breakfasts.Commands;

public class CreateBreakfastValidator : AbstractValidator<CreateBreakfastCommand>
{
    public CreateBreakfastValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}
