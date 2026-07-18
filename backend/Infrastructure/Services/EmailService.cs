using System.Net;
using System.Net.Mail;
using Application.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services;

public class EmailService(IConfiguration configuration) : IEmailService
{
    public async Task SendAsync(string to, string subject, string htmlBody, CancellationToken ct = default)
    {
        var smtp = configuration.GetSection("Smtp");
        var host = smtp["Host"] ?? throw new InvalidOperationException("Smtp:Host is not configured.");
        var port = int.Parse(smtp["Port"] ?? "587");
        var user = smtp["User"] ?? string.Empty;
        var password = smtp["Password"] ?? string.Empty;
        var from = smtp["From"] ?? user;
        var enableSsl = bool.Parse(smtp["EnableSsl"] ?? "true");

#pragma warning disable SYSLIB0006 // SmtpClient is functional and MailKit is not in the dependency tree
        using var client = new SmtpClient(host, port)
        {
            Credentials = new NetworkCredential(user, password),
            EnableSsl = enableSsl
        };

        var message = new MailMessage(from, to, subject, htmlBody) { IsBodyHtml = true };
        await client.SendMailAsync(message, ct);
#pragma warning restore SYSLIB0006
    }
}
