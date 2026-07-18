using Application.Interfaces;
using Domain.Common;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Application.Features.Auth.Commands.ResendConfirmationEmail;

public class ResendConfirmationEmailHandler(
    UserManager<AppUser> userManager,
    IEmailService emailService,
    IConfiguration configuration) : IRequestHandler<ResendConfirmationEmailCommand, Result<string>>
{
    private const string Message = "If this email is registered and unconfirmed, a new link has been sent.";

    public async Task<Result<string>> Handle(ResendConfirmationEmailCommand request, CancellationToken ct)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user is null || user.EmailConfirmed)
            return Message;

        var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
        var frontendUrl = configuration["Frontend:Url"] ?? "http://localhost:5173";
        var link = $"{frontendUrl}/confirm-email?userId={user.Id}&token={Uri.EscapeDataString(token)}";

        await emailService.SendAsync(
            request.Email,
            "Confirm your email – BookingClone",
            $"""
             <p>Hi {user.FirstName},</p>
             <p>Please <a href="{link}">confirm your email address</a> to activate your account.</p>
             <p>If you did not register, you can ignore this email.</p>
             """,
            ct);

        return Message;
    }
}
