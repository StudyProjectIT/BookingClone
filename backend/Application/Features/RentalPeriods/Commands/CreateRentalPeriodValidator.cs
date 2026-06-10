using FluentValidation;

namespace Application.Features.RentalPeriods.Commands;

public class CreateRentalPeriodValidator : AbstractValidator<CreateRentalPeriodCommand>
{
    public CreateRentalPeriodValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}
