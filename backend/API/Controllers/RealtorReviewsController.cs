using API.Common;
using Application.Features.RealtorReviews.Commands.CreateRealtorReview;
using Application.Features.RealtorReviews.Commands.DeleteRealtorReview;
using Application.Features.RealtorReviews.Commands.UpdateRealtorReview;
using Application.Features.RealtorReviews.Queries.GetRealtorReviewById;
using Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/realtor-reviews")]
public class RealtorReviewsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id, CancellationToken ct)
        => (await mediator.Send(new GetRealtorReviewByIdQuery(id), ct)).ToActionResult();

    [HttpPost]
    [Authorize(Roles = Roles.Customer)]
    public async Task<IActionResult> Create([FromBody] CreateRealtorReviewCommand command, CancellationToken ct)
        => (await mediator.Send(command, ct)).ToCreatedResult();

    [HttpPut("{id:long}")]
    [Authorize(Roles = Roles.Customer)]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateRealtorReviewCommand command, CancellationToken ct)
        => (await mediator.Send(command with { Id = id }, ct)).ToNoContentResult();

    [HttpDelete("{id:long}")]
    [Authorize(Roles = Roles.Admin + "," + Roles.Customer)]
    public async Task<IActionResult> Delete(long id, CancellationToken ct)
        => (await mediator.Send(new DeleteRealtorReviewCommand(id), ct)).ToNoContentResult();
}
