using Domain.Entities.Identity;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RefreshTokenRepository(AppDbContext context) : IRefreshTokenRepository
{
    public async Task<RefreshToken?> GetByTokenAsync(string token, CancellationToken ct = default)
    {
        return await context.RefreshTokens
            .Include(rt => rt.User)
            .FirstOrDefaultAsync(rt => rt.Token == token, ct);
    }

    public async Task<RefreshToken> AddAsync(RefreshToken token, CancellationToken ct = default)
    {
        context.RefreshTokens.Add(token);
        await context.SaveChangesAsync(ct);
        return token;
    }

    public async Task RevokeAsync(long id, CancellationToken ct = default)
    {
        var token = await context.RefreshTokens.FindAsync(new object[] { id }, ct);
        if (token is not null)
        {
            token.IsRevoked = true;
            await context.SaveChangesAsync(ct);
        }
    }
}
