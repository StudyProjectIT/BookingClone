using API.Common;
using Application.Features.HotelReviews.Commands.CreateHotelReview;
using Application.Features.HotelReviews.Commands.DeleteHotelReview;
using Application.Features.HotelReviews.Commands.UpdateHotelReview;
using Application.Features.HotelReviews.Queries.GetHotelReviewById;
using Application.Features.HotelReviews.Queries.GetHotelReviewsByHotelId;
using Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/hotel-reviews")]
public class HotelReviewsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id, CancellationToken ct)
        => (await mediator.Send(new GetHotelReviewByIdQuery(id), ct)).ToActionResult();

    [HttpGet("by-hotel/{hotelId:long}")]
    public async Task<IActionResult> GetByHotel(long hotelId, CancellationToken ct)
        => (await mediator.Send(new GetHotelReviewsByHotelIdQuery(hotelId), ct)).ToActionResult();

    [HttpPost]
    [Authorize(Roles = Roles.Customer)]
    public async Task<IActionResult> Create([FromBody] CreateHotelReviewCommand command, CancellationToken ct)
        => (await mediator.Send(command, ct)).ToCreatedResult();

    [HttpPut("{id:long}")]
    [Authorize(Roles = Roles.Customer)]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateHotelReviewCommand command, CancellationToken ct)
        => (await mediator.Send(command with { Id = id }, ct)).ToNoContentResult();

    [HttpDelete("{id:long}")]
    [Authorize(Roles = Roles.Admin + "," + Roles.Customer)]
    public async Task<IActionResult> Delete(long id, CancellationToken ct)
        => (await mediator.Send(new DeleteHotelReviewCommand(id), ct)).ToNoContentResult();
}
