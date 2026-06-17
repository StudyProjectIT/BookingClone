using Application.Interfaces;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Messages.Commands.DeleteMessage;

public class DeleteMessageHandler(IRepository<Message> repository, ICurrentUserService currentUser)
    : IRequestHandler<DeleteMessageCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteMessageCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Message with id {request.Id} not found.");

        if (entity.AuthorId != currentUser.GetUserId())
            return Error.Forbidden("You do not have access to this resource.");

        await repository.DeleteAsync(request.Id, ct);
        return true;
    }
}
