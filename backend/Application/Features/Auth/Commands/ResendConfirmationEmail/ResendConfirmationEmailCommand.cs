using Domain.Common;
using MediatR;

namespace Application.Features.Auth.Commands.ResendConfirmationEmail;

public record ResendConfirmationEmailCommand(string Email) : IRequest<Result<string>>;
