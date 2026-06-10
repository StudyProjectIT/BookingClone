using FluentValidation;

namespace Application.Features.Languages.Commands.CreateLanguage;

public class CreateLanguageValidator : AbstractValidator<CreateLanguageCommand>
{
    public CreateLanguageValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}
