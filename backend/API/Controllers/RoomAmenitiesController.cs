using API.Common;
using Application.Features.RoomAmenities.Commands.CreateRoomAmenity;
using Application.Features.RoomAmenities.Commands.DeleteRoomAmenity;
using Application.Features.RoomAmenities.Commands.UpdateRoomAmenity;
using Application.Features.RoomAmenities.Queries.GetAllRoomAmenities;
using Application.Features.RoomAmenities.Queries.GetRoomAmenityById;
using Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/room-amenities")]
public class RoomAmenitiesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 20, CancellationToken ct = default)
        => (await mediator.Send(new GetAllRoomAmenitiesQuery(page, pageSize), ct)).ToActionResult();

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id, CancellationToken ct)
        => (await mediator.Send(new GetRoomAmenityByIdQuery(id), ct)).ToActionResult();

    [HttpPost]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Create([FromBody] CreateRoomAmenityCommand command, CancellationToken ct)
        => (await mediator.Send(command, ct)).ToCreatedResult();

    [HttpPut("{id:long}")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateRoomAmenityCommand command, CancellationToken ct)
        => (await mediator.Send(command with { Id = id }, ct)).ToNoContentResult();

    [HttpDelete("{id:long}")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Delete(long id, CancellationToken ct)
        => (await mediator.Send(new DeleteRoomAmenityCommand(id), ct)).ToNoContentResult();
}
