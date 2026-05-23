using API.Common;
using Application.DTOs.Auth;
using Application.Features.Auth.Commands.Register;
using Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService,
    IMediator mediator) : ControllerBase
{
    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto, CancellationToken ct)
    {
        var command = new RegisterCommand(dto);
        var result = await mediator.Send(command);
        return result.ToActionResult();
    }
       // => (await authService.RegisterAsync(dto, ct)).ToActionResult();

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginDto dto, CancellationToken ct)
        => (await authService.LoginAsync(dto, ct)).ToActionResult();

    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> Me(CancellationToken ct)
    {
        var idClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!long.TryParse(idClaim, out var userId))
            return Unauthorized();

        return (await authService.GetCurrentUserAsync(userId, ct)).ToActionResult();
    }
}
