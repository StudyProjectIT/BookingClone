using Domain.Common;
using MediatR;

namespace Application.Features.Auth.Commands.RevokeToken;

public record RevokeTokenCommand(string Token) : IRequest<Result<bool>>;
