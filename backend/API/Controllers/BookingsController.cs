using System.Security.Claims;
using API.Common;
using Application.DTOs;
using Application.Features.Bookings.Commands.CreateBooking;
using Application.Features.Bookings.Commands.DeleteBooking;
using Application.Features.Bookings.Commands.UpdateBooking;
using Application.Features.Bookings.Queries.GetAllBookings;
using Application.Features.Bookings.Queries.GetBookingById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class BookingsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 20, CancellationToken ct = default)
    {
        var idClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!long.TryParse(idClaim, out var customerId))
            return Unauthorized();

        return (await mediator.Send(new GetAllBookingsQuery(customerId, page, pageSize), ct)).ToActionResult();
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id, CancellationToken ct)
        => (await mediator.Send(new GetBookingByIdQuery(id), ct)).ToActionResult();

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookingDto dto, CancellationToken ct)
    {
        var idClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!long.TryParse(idClaim, out var customerId))
            return Unauthorized();

        var command = new CreateBookingCommand(
            customerId,
            dto.RoomVariantId,
            dto.Quantity,
            dto.CheckIn,
            dto.CheckOut,
            dto.TotalPrice,
            dto.PersonalWishes
        );
        return (await mediator.Send(command, ct)).ToCreatedResult();
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] CreateBookingDto dto, CancellationToken ct)
    {
        var command = new UpdateBookingCommand(
            id,
            dto.RoomVariantId,
            dto.Quantity,
            dto.CheckIn,
            dto.CheckOut,
            dto.TotalPrice,
            dto.PersonalWishes
        );
        return (await mediator.Send(command, ct)).ToNoContentResult();
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id, CancellationToken ct)
        => (await mediator.Send(new DeleteBookingCommand(id), ct)).ToNoContentResult();
}
