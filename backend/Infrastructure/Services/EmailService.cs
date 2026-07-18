using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System.Net;
using System.Net.Mail;
using static Org.BouncyCastle.Math.EC.ECCurve;

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
        //using var client = new SmtpClient(host, port)
        //{
        //    Credentials = new NetworkCredential(user, password),
        //    EnableSsl = enableSsl
        //};

        //var message = new MailMessage(from, to, subject, htmlBody) { IsBodyHtml = true };
        //await client.SendMailAsync(message, ct);
#pragma warning restore SYSLIB0006

        //створюємо повідомлення для відправки
        var mimeMessage = new MimeMessage();
        //від кого буде лист
        mimeMessage.From.Add(new MailboxAddress("ivan", from));
        //Кому піде лист
        mimeMessage.To.Add(new MailboxAddress("semen", to));
        //Тема листа
        mimeMessage.Subject = subject;
        TextPart textPart = new TextPart("html")
        {
            Text = htmlBody
        };


        //Тіло листа
        var multiPart = new Multipart();
        multiPart.Add(textPart);
        //multiPart.Add(attach);

        mimeMessage.Body = multiPart;

        try
        {
            using var client = new MailKit.Net.Smtp.SmtpClient();
            client.Connect(host, port, true);
            client.Authenticate(user, password);
            client.Send(mimeMessage);
            client.Disconnect(true);
            Console.WriteLine("---------Лист успішно надіслано!---------");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Щось пішло не так " + ex.Message);
        }
    }
}
