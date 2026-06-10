using FluentValidation;

namespace Application.Features.Citizenships.Commands;

public class CreateCitizenshipValidator : AbstractValidator<CreateCitizenshipCommand>
{
    public CreateCitizenshipValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}
