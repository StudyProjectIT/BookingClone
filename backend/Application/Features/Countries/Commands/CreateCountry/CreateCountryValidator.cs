using FluentValidation;

namespace Application.Features.Countries.Commands.CreateCountry;

public class CreateCountryValidator : AbstractValidator<CreateCountryCommand>
{
    public CreateCountryValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Image).NotEmpty().MaximumLength(500);
    }
}
