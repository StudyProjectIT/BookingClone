using FluentValidation;

namespace Application.Features.Auth.Commands.ConfirmEmail;

public class ConfirmEmailValidator : AbstractValidator<ConfirmEmailCommand>
{
    public ConfirmEmailValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0).WithName("UserId");
        RuleFor(x => x.Token).NotEmpty().WithName("Token");
    }
}
