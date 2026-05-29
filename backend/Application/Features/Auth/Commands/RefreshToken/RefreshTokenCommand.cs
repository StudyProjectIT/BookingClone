using Application.DTOs.Auth;
using Domain.Common;
using MediatR;

namespace Application.Features.Auth.Commands.RefreshToken;

public record RefreshTokenCommand(string Token) : IRequest<Result<AuthResponseDto>>;
