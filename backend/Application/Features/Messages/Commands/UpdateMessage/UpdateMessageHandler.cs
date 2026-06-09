using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Messages.Commands.UpdateMessage;

public class UpdateMessageHandler(IRepository<Message> repository)
    : IRequestHandler<UpdateMessageCommand, Result<MessageDto>>
{
    public async Task<Result<MessageDto>> Handle(UpdateMessageCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Message with id {request.Id} not found.");

        if (string.IsNullOrWhiteSpace(request.Text))
            return Error.Validation("Message text is required.");

        entity.Text = request.Text;
        entity.UpdatedAtUtc = DateTime.UtcNow;
        await repository.UpdateAsync(entity, ct);
        return MessageMappings.MapToDto(entity);
    }
}
