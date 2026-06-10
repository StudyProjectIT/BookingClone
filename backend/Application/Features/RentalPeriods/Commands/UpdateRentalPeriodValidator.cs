using FluentValidation;

namespace Application.Features.RentalPeriods.Commands;

public class UpdateRentalPeriodValidator : AbstractValidator<UpdateRentalPeriodCommand>
{
    public UpdateRentalPeriodValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}
