using Application.Models.Accounts;
using Domain.Constants;
using Domain.Entities.Identity;

namespace Application.Interfaces;

public interface IAuthService {
	Task<AppUser> CreateUserAsync(UserDto userDto, CreateUserType type, CancellationToken cancellationToken = default);
}
