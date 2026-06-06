using Application.Models.Email;

namespace Application.Interfaces;

public interface IEmailService {
	Task SendMessageAsync(EmailDto email, CancellationToken cancellationToken = default);
}
