using Domain.Common;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Auth.Commands.ConfirmEmail;

public class ConfirmEmailHandler(UserManager<AppUser> userManager)
    : IRequestHandler<ConfirmEmailCommand, Result<string>>
{
    public async Task<Result<string>> Handle(ConfirmEmailCommand request, CancellationToken ct)
    {
        var user = await userManager.FindByIdAsync(request.UserId.ToString());
        if (user is null)
            return Error.NotFound("User not found.");

        if (user.EmailConfirmed)
            return "Email is already confirmed.";

        var result = await userManager.ConfirmEmailAsync(user, request.Token);
        if (!result.Succeeded)
            return Error.Validation(string.Join("; ", result.Errors.Select(e => e.Description)));

        return "Email confirmed successfully. You can now sign in.";
    }
}
