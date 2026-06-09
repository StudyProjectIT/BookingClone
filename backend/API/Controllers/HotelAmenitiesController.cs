using API.Common;
using Application.Features.HotelAmenities.Commands.CreateHotelAmenity;
using Application.Features.HotelAmenities.Commands.DeleteHotelAmenity;
using Application.Features.HotelAmenities.Commands.UpdateHotelAmenity;
using Application.Features.HotelAmenities.Queries.GetAllHotelAmenities;
using Application.Features.HotelAmenities.Queries.GetHotelAmenityById;
using Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/hotel-amenities")]
public class HotelAmenitiesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 20, CancellationToken ct = default)
        => (await mediator.Send(new GetAllHotelAmenitiesQuery(page, pageSize), ct)).ToActionResult();

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id, CancellationToken ct)
        => (await mediator.Send(new GetHotelAmenityByIdQuery(id), ct)).ToActionResult();

    [HttpPost]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Create([FromBody] CreateHotelAmenityCommand command, CancellationToken ct)
        => (await mediator.Send(command, ct)).ToCreatedResult();

    [HttpPut("{id:long}")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateHotelAmenityCommand command, CancellationToken ct)
        => (await mediator.Send(command with { Id = id }, ct)).ToNoContentResult();

    [HttpDelete("{id:long}")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Delete(long id, CancellationToken ct)
        => (await mediator.Send(new DeleteHotelAmenityCommand(id), ct)).ToNoContentResult();
}
