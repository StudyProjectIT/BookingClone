using FluentValidation;

namespace Application.Features.Genders.Commands;

public class UpdateGenderValidator : AbstractValidator<UpdateGenderCommand>
{
    public UpdateGenderValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
    }
}
