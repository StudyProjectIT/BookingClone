using API.Common;
using Application.Features.Messages.Commands.CreateMessage;
using Application.Features.Messages.Commands.DeleteMessage;
using Application.Features.Messages.Commands.UpdateMessage;
using Application.Features.Messages.Queries.GetMessagesByChatId;
using Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessagesController(IMediator mediator) : ControllerBase
{
    [HttpGet("by-chat/{chatId:long}")]
    [Authorize]
    public async Task<IActionResult> GetByChatId(long chatId, CancellationToken ct)
        => (await mediator.Send(new GetMessagesByChatIdQuery(chatId), ct)).ToActionResult();

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] CreateMessageCommand command, CancellationToken ct)
        => (await mediator.Send(command, ct)).ToCreatedResult();

    [HttpPut("{id:long}")]
    [Authorize]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateMessageCommand command, CancellationToken ct)
        => (await mediator.Send(command with { Id = id }, ct)).ToNoContentResult();

    [HttpDelete("{id:long}")]
    [Authorize]
    public async Task<IActionResult> Delete(long id, CancellationToken ct)
        => (await mediator.Send(new DeleteMessageCommand(id), ct)).ToNoContentResult();
}
