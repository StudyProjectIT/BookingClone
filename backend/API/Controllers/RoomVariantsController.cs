using API.Common;
using Application.Features.RoomVariants.Commands.CreateRoomVariant;
using Application.Features.RoomVariants.Commands.DeleteRoomVariant;
using Application.Features.RoomVariants.Commands.UpdateRoomVariant;
using Application.Features.RoomVariants.Queries.GetRoomVariantById;
using Application.Features.RoomVariants.Queries.GetRoomVariantsByRoomId;
using Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/room-variants")]
public class RoomVariantsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id, CancellationToken ct)
        => (await mediator.Send(new GetRoomVariantByIdQuery(id), ct)).ToActionResult();

    [HttpGet("by-room/{roomId:long}")]
    public async Task<IActionResult> GetByRoomId(long roomId, CancellationToken ct)
        => (await mediator.Send(new GetRoomVariantsByRoomIdQuery(roomId), ct)).ToActionResult();

    [HttpPost]
    [Authorize(Roles = Roles.Admin + "," + Roles.Realtor)]
    public async Task<IActionResult> Create([FromBody] CreateRoomVariantCommand command, CancellationToken ct)
        => (await mediator.Send(command, ct)).ToCreatedResult();

    [HttpPut("{id:long}")]
    [Authorize(Roles = Roles.Admin + "," + Roles.Realtor)]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateRoomVariantCommand command, CancellationToken ct)
        => (await mediator.Send(command with { Id = id }, ct)).ToNoContentResult();

    [HttpDelete("{id:long}")]
    [Authorize(Roles = Roles.Admin + "," + Roles.Realtor)]
    public async Task<IActionResult> Delete(long id, CancellationToken ct)
        => (await mediator.Send(new DeleteRoomVariantCommand(id), ct)).ToNoContentResult();
}
