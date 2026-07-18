using Domain.Common;
using MediatR;

namespace Application.Features.Auth.Commands.ConfirmEmail;

public record ConfirmEmailCommand(long UserId, string Token) : IRequest<Result<string>>;
