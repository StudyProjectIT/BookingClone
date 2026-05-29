using Domain.Entities.Identity;

namespace Domain.Interfaces;

public interface IRefreshTokenRepository
{
    Task<RefreshToken?> GetByTokenAsync(string token, CancellationToken ct = default);
    Task<RefreshToken> AddAsync(RefreshToken token, CancellationToken ct = default);
    Task RevokeAsync(long id, CancellationToken ct = default);
}
