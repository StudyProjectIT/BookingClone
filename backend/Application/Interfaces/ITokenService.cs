using Domain.Entities.Identity;

namespace Application.Interfaces;

public interface ITokenService
{
    (string Token, DateTime ExpiresAt) CreateToken(AppUser user, IList<string> roles);
    string GenerateRefreshToken();
}
