using Application.DTOs.Auth;
using Domain.Common;

namespace Application.Interfaces;

public interface IAuthService
{
    Task<Result<AuthResponseDto>> RegisterAsync(RegisterDto dto, CancellationToken ct = default);
    Task<Result<AuthResponseDto>> LoginAsync(LoginDto dto, CancellationToken ct = default);
    Task<Result<UserDto>> GetCurrentUserAsync(long userId, CancellationToken ct = default);
}
