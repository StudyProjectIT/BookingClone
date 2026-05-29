using Application.DTOs.Auth;
using Domain.Common;
using MediatR;

namespace Application.Features.Auth.Commands.Login;

public record LoginCommand(LoginDto Dto) : IRequest<Result<AuthResponseDto>>;
