using FluentValidation;

namespace Application.Features.Auth.Commands.ResendConfirmationEmail;

public class ResendConfirmationEmailValidator : AbstractValidator<ResendConfirmationEmailCommand>
{
    public ResendConfirmationEmailValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress().WithName("Email");
    }
}
