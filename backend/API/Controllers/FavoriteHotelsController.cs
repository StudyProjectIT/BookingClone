using API.Common;
using Application.Features.FavoriteHotels.Commands.AddFavoriteHotel;
using Application.Features.FavoriteHotels.Commands.RemoveFavoriteHotel;
using Application.Features.FavoriteHotels.Queries.GetFavoriteHotelsByCustomerId;
using Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/favorite-hotels")]
public class FavoriteHotelsController(IMediator mediator) : ControllerBase
{
    [HttpGet("by-customer/{customerId:long}")]
    [Authorize]
    public async Task<IActionResult> GetByCustomerId(long customerId, CancellationToken ct)
        => (await mediator.Send(new GetFavoriteHotelsByCustomerIdQuery(customerId), ct)).ToActionResult();

    [HttpPost]
    [Authorize(Roles = Roles.Customer)]
    public async Task<IActionResult> Add([FromBody] AddFavoriteHotelCommand command, CancellationToken ct)
        => (await mediator.Send(command, ct)).ToCreatedResult();

    [HttpDelete]
    [Authorize(Roles = Roles.Customer)]
    public async Task<IActionResult> Remove([FromBody] RemoveFavoriteHotelCommand command, CancellationToken ct)
        => (await mediator.Send(command, ct)).ToNoContentResult();
}
