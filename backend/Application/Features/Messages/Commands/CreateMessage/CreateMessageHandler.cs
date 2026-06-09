using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Messages.Commands.CreateMessage;

public class CreateMessageHandler(IRepository<Message> repository)
    : IRequestHandler<CreateMessageCommand, Result<MessageDto>>
{
    public async Task<Result<MessageDto>> Handle(CreateMessageCommand request, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(request.Text))
            return Error.Validation("Message text is required.");

        var entity = new Message
        {
            Text = request.Text,
            ChatId = request.ChatId,
            AuthorId = request.AuthorId,
            CreatedAtUtc = DateTime.UtcNow
        };
        var created = await repository.AddAsync(entity, ct);
        return MessageMappings.MapToDto(created);
    }
}
