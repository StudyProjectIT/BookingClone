using API.Common;
using Application.Features.BankCards.Commands.CreateBankCard;
using Application.Features.BankCards.Commands.DeleteBankCard;
using Application.Features.BankCards.Commands.UpdateBankCard;
using Application.Features.BankCards.Queries.GetBankCardById;
using Application.Features.BankCards.Queries.GetBankCardsByCustomerId;
using Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/bank-cards")]
public class BankCardsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id:long}")]
    [Authorize]
    public async Task<IActionResult> GetById(long id, CancellationToken ct)
        => (await mediator.Send(new GetBankCardByIdQuery(id), ct)).ToActionResult();

    [HttpGet("by-customer/{customerId:long}")]
    [Authorize]
    public async Task<IActionResult> GetByCustomerId(long customerId, CancellationToken ct)
        => (await mediator.Send(new GetBankCardsByCustomerIdQuery(customerId), ct)).ToActionResult();

    [HttpPost]
    [Authorize(Roles = Roles.Customer)]
    public async Task<IActionResult> Create([FromBody] CreateBankCardCommand command, CancellationToken ct)
        => (await mediator.Send(command, ct)).ToCreatedResult();

    [HttpPut("{id:long}")]
    [Authorize(Roles = Roles.Customer)]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateBankCardCommand command, CancellationToken ct)
        => (await mediator.Send(command with { Id = id }, ct)).ToNoContentResult();

    [HttpDelete("{id:long}")]
    [Authorize(Roles = Roles.Customer + "," + Roles.Admin)]
    public async Task<IActionResult> Delete(long id, CancellationToken ct)
        => (await mediator.Send(new DeleteBankCardCommand(id), ct)).ToNoContentResult();
}
