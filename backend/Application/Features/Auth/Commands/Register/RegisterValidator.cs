using FluentValidation;

namespace Application.Features.Auth.Commands.Register;

public class RegisterValidator : AbstractValidator<RegisterCommand>
{
    public RegisterValidator()
    {
        RuleFor(x => x.dto.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.dto.UserName).NotEmpty().MinimumLength(3).MaximumLength(64);
        RuleFor(x => x.dto.Password).NotEmpty().MinimumLength(8);
        RuleFor(x => x.dto.FirstName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.dto.LastName).NotEmpty().MaximumLength(100);
    }
}
