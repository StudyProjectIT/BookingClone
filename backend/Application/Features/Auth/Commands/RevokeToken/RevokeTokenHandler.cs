using Domain.Common;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Auth.Commands.RevokeToken;

public class RevokeTokenHandler(IRefreshTokenRepository refreshTokenRepository)
    : IRequestHandler<RevokeTokenCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(RevokeTokenCommand request, CancellationToken ct)
    {
        var token = await refreshTokenRepository.GetByTokenAsync(request.Token, ct);
        if (token is null)
            return Error.NotFound("Refresh token not found.");

        if (token.IsRevoked)
            return Error.Conflict("Token is already revoked.");

        await refreshTokenRepository.RevokeAsync(token.Id, ct);
        return true;
    }
}
