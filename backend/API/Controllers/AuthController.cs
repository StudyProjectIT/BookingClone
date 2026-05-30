using System.Security.Claims;
using API.Common;
using Application.DTOs.Auth;
using Application.Features.Auth.Commands.Login;
using Application.Features.Auth.Commands.RefreshToken;
using Application.Features.Auth.Commands.Register;
using Application.Features.Auth.Commands.RevokeToken;
using Application.Features.Auth.Commands.UpdateProfile;
using Application.Features.Auth.Queries.GetCurrentUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto, CancellationToken ct)
        => (await mediator.Send(new RegisterCommand(dto), ct)).ToActionResult();

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginDto dto, CancellationToken ct)
        => (await mediator.Send(new LoginCommand(dto), ct)).ToActionResult();

    [HttpPost("refresh")]
    [AllowAnonymous]
    public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequest request, CancellationToken ct)
        => (await mediator.Send(new RefreshTokenCommand(request.Token), ct)).ToActionResult();

    [HttpPost("revoke")]
    [Authorize]
    public async Task<IActionResult> Revoke([FromBody] RefreshTokenRequest request, CancellationToken ct)
        => (await mediator.Send(new RevokeTokenCommand(request.Token), ct)).ToNoContentResult();

    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> Me(CancellationToken ct)
    {
        var idClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!long.TryParse(idClaim, out var userId))
            return Unauthorized();

        return (await mediator.Send(new GetCurrentUserQuery(userId), ct)).ToActionResult();
    }

    [HttpPatch("profile")]
    [Authorize]
    public async Task<IActionResult> UpdateProfile([FromBody] ProfileUpdateDto dto, CancellationToken ct)
    {
        var idClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!long.TryParse(idClaim, out var userId))
            return Unauthorized();

        return (await mediator.Send(new UpdateProfileCommand(userId, dto), ct)).ToActionResult();
    }
}

public record RefreshTokenRequest(string Token);
