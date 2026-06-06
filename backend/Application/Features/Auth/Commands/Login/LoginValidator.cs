using FluentValidation;

namespace Application.Features.Auth.Commands.Login;

public class LoginValidator : AbstractValidator<LoginCommand>
{
    public LoginValidator()
    {
        RuleFor(x => x.Dto.EmailOrUserName).NotEmpty().WithName("Email or username");
        RuleFor(x => x.Dto.Password).NotEmpty().WithName("Password");
    }
}
