using Application.DTOs.Auth;
using Domain.Common;
using MediatR;

namespace Application.Features.Auth.Commands.Register;

public record RegisterCommand(RegisterDto dto) : IRequest<Result<AuthResponseDto>>;
