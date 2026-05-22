using Application.DTOs.Auth;
using Application.Interfaces;
using Domain.Common;
using Domain.Constants;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Application.Services;

public class AuthService(
    UserManager<AppUser> userManager,
    SignInManager<AppUser> signInManager,
    ITokenService tokenService) : IAuthService
{
    public async Task<Result<AuthResponseDto>> RegisterAsync(RegisterDto dto, CancellationToken ct = default)
    {
        if (await userManager.FindByEmailAsync(dto.Email) is not null)
            return Error.Conflict("Email is already taken.");

        if (await userManager.FindByNameAsync(dto.UserName) is not null)
            return Error.Conflict("Username is already taken.");

        var user = new Customer
        {
            Email = dto.Email,
            UserName = dto.UserName,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Photo = "default.jpg"
        };

        var createResult = await userManager.CreateAsync(user, dto.Password);
        if (!createResult.Succeeded)
            return Error.Validation(string.Join("; ", createResult.Errors.Select(e => e.Description)));

        var roleResult = await userManager.AddToRoleAsync(user, Roles.Customer);
        if (!roleResult.Succeeded)
            return Error.Unexpected(string.Join("; ", roleResult.Errors.Select(e => e.Description)));

        return await BuildAuthResponseAsync(user);
    }

    public async Task<Result<AuthResponseDto>> LoginAsync(LoginDto dto, CancellationToken ct = default)
    {
        var user = await userManager.FindByEmailAsync(dto.EmailOrUserName)
                   ?? await userManager.FindByNameAsync(dto.EmailOrUserName);

        if (user is null)
            return Error.Unauthorized("Invalid credentials.");

        var check = await signInManager.CheckPasswordSignInAsync(user, dto.Password, lockoutOnFailure: false);
        if (!check.Succeeded)
            return Error.Unauthorized("Invalid credentials.");

        return await BuildAuthResponseAsync(user);
    }

    public async Task<Result<UserDto>> GetCurrentUserAsync(long userId, CancellationToken ct = default)
    {
        var user = await userManager.FindByIdAsync(userId.ToString());
        if (user is null)
            return Error.NotFound("User not found.");

        var roles = await userManager.GetRolesAsync(user);
        return MapToUserDto(user, roles);
    }

    private async Task<Result<AuthResponseDto>> BuildAuthResponseAsync(AppUser user)
    {
        var roles = await userManager.GetRolesAsync(user);
        var (token, expiresAt) = tokenService.CreateToken(user, roles);

        return new AuthResponseDto
        {
            Token = token,
            ExpiresAt = expiresAt,
            User = MapToUserDto(user, roles)
        };
    }

    private static UserDto MapToUserDto(AppUser user, IList<string> roles) => new()
    {
        Id = user.Id,
        UserName = user.UserName ?? string.Empty,
        Email = user.Email ?? string.Empty,
        FirstName = user.FirstName,
        LastName = user.LastName,
        Roles = roles
    };
}
