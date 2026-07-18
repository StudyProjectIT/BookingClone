using Domain.Common;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Auth.Commands.ResetPassword;

public class ResetPasswordHandler(UserManager<AppUser> userManager)
    : IRequestHandler<ResetPasswordCommand, Result<string>>
{
    public async Task<Result<string>> Handle(ResetPasswordCommand request, CancellationToken ct)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user is null)
            return Error.NotFound("User not found.");

        var result = await userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);
        if (!result.Succeeded)
            return Error.Validation(string.Join("; ", result.Errors.Select(e => e.Description)));

        return "Password reset successfully. You can now sign in with your new password.";
    }
}
