using FluentValidation;

namespace Application.Features.Auth.Commands.ResetPassword;

public class ResetPasswordValidator : AbstractValidator<ResetPasswordCommand>
{
    public ResetPasswordValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress().WithName("Email");
        RuleFor(x => x.Token).NotEmpty().WithName("Token");
        RuleFor(x => x.NewPassword).NotEmpty().MinimumLength(8).WithName("New Password");
    }
}
