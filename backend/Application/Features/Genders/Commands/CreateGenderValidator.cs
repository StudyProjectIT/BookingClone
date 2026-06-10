using FluentValidation;

namespace Application.Features.Genders.Commands;

public class CreateGenderValidator : AbstractValidator<CreateGenderCommand>
{
    public CreateGenderValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
    }
}
