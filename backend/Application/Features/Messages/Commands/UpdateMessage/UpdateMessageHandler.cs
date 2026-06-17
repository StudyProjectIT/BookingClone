using Application.DTOs;
using Application.Interfaces;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Messages.Commands.UpdateMessage;

public class UpdateMessageHandler(IRepository<Message> repository, ICurrentUserService currentUser)
    : IRequestHandler<UpdateMessageCommand, Result<MessageDto>>
{
    public async Task<Result<MessageDto>> Handle(UpdateMessageCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Message with id {request.Id} not found.");

        if (entity.AuthorId != currentUser.GetUserId())
            return Error.Forbidden("You do not have access to this resource.");

        entity.Text = request.Text;
        entity.UpdatedAtUtc = DateTime.UtcNow;
        await repository.UpdateAsync(entity, ct);
        return MessageMappings.MapToDto(entity);
    }
}
