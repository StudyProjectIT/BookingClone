using API.Common;
using Application.Features.HotelPhotos.Commands.CreateHotelPhoto;
using Application.Features.HotelPhotos.Commands.DeleteHotelPhoto;
using Application.Features.HotelPhotos.Queries.GetHotelPhotosByHotelId;
using Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/hotel-photos")]
public class HotelPhotosController(IMediator mediator) : ControllerBase
{
    [HttpGet("by-hotel/{hotelId:long}")]
    public async Task<IActionResult> GetByHotelId(long hotelId, CancellationToken ct)
        => (await mediator.Send(new GetHotelPhotosByHotelIdQuery(hotelId), ct)).ToActionResult();

    [HttpPost]
    [Authorize(Roles = Roles.Admin + "," + Roles.Realtor)]
    public async Task<IActionResult> Create([FromBody] CreateHotelPhotoCommand command, CancellationToken ct)
        => (await mediator.Send(command, ct)).ToCreatedResult();

    [HttpDelete("{id:long}")]
    [Authorize(Roles = Roles.Admin + "," + Roles.Realtor)]
    public async Task<IActionResult> Delete(long id, CancellationToken ct)
        => (await mediator.Send(new DeleteHotelPhotoCommand(id), ct)).ToNoContentResult();
}
