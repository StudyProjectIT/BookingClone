using Application.Interfaces;
using Domain.Common;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Application.Features.Auth.Commands.ForgotPassword;

public class ForgotPasswordHandler(
    UserManager<AppUser> userManager,
    IEmailService emailService,
    IConfiguration configuration) : IRequestHandler<ForgotPasswordCommand, Result<string>>
{
    private const string Message = "If this email is registered, a password reset link has been sent.";

    public async Task<Result<string>> Handle(ForgotPasswordCommand request, CancellationToken ct)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user is null || !user.EmailConfirmed)
            return Message;

        var token = await userManager.GeneratePasswordResetTokenAsync(user);
        var frontendUrl = configuration["Frontend:Url"] ?? "http://localhost:5173";
        var link = $"{frontendUrl}/reset-password?email={Uri.EscapeDataString(request.Email)}&token={Uri.EscapeDataString(token)}";

        await emailService.SendAsync(
            request.Email,
            "Reset your password – BookingClone",
            $"""
             <p>Hi {user.FirstName},</p>
             <p>We received a request to reset your password. Click the link below to choose a new one:</p>
             <p><a href="{link}">Reset password</a></p>
             <p>This link expires in 24 hours. If you did not request a reset, you can ignore this email.</p>
             """,
            ct);

        return Message;
    }
}
