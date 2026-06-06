using API.Common;
using Application.Features.Hotels.Commands.CreateHotel;
using Application.Features.Hotels.Commands.DeleteHotel;
using Application.Features.Hotels.Commands.UpdateHotel;
using Application.Features.Hotels.Queries.GetAllHotels;
using Application.Features.Hotels.Queries.GetHotelById;
using Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HotelsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetHotels([FromQuery] int page = 1, [FromQuery] int pageSize = 20, CancellationToken ct = default)
        => (await mediator.Send(new GetAllHotelsQuery(page, pageSize), ct)).ToActionResult();

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetHotel(int id, CancellationToken ct)
        => (await mediator.Send(new GetHotelByIdQuery(id), ct)).ToActionResult();

    [HttpPost]
    [Authorize(Roles = Roles.Admin + "," + Roles.Realtor)]
    public async Task<IActionResult> CreateHotel([FromBody] CreateHotelCommand command, CancellationToken ct)
        => (await mediator.Send(command, ct)).ToCreatedResult();

    [HttpPut("{id:int}")]
    [Authorize(Roles = Roles.Admin + "," + Roles.Realtor)]
    public async Task<IActionResult> UpdateHotel(int id, [FromBody] UpdateHotelCommand command, CancellationToken ct)
        => (await mediator.Send(command with { Id = id }, ct)).ToNoContentResult();

    [HttpDelete("{id:int}")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> DeleteHotel(int id, CancellationToken ct)
        => (await mediator.Send(new DeleteHotelCommand(id), ct)).ToNoContentResult();
}
