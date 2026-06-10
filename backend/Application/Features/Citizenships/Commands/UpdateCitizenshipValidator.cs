using FluentValidation;

namespace Application.Features.Citizenships.Commands;

public class UpdateCitizenshipValidator : AbstractValidator<UpdateCitizenshipCommand>
{
    public UpdateCitizenshipValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}
